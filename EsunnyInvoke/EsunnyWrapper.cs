using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CalmBeltFund.Trading.Esunny
{
  internal class PInvokeUtility
  {
    static Encoding encodingGB2312 = Encoding.GetEncoding(936);

    public static string GetUnicodeString(byte[] str)
    {

      if (str == null)
      {
        return "";
      }

      byte[] unicodeStr = Encoding.Convert(encodingGB2312, Encoding.Unicode, str);

      return Encoding.Unicode.GetString(unicodeStr).TrimEnd('\0');
    }

    public static T GetObjectFromIntPtr<T>(IntPtr handler)
    {
      try
      {
        if (handler == IntPtr.Zero)
        {
          return default(T);
        }
        else
        {
          return (T)Marshal.PtrToStructure(handler, typeof(T));
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public static object GetObjectFromIntPtr(Type t, IntPtr handler)
    {
      try
      {
        if (handler == IntPtr.Zero)
        {
          return null;
        }
        else
        {
          return Marshal.PtrToStructure(handler, t);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }

  internal class EsunnyWrapper
  {
    [DllImport("EsunnyWrapper.dll")]
    internal static extern bool CertApi(string cert,string logPath);

    //[DllImport("EsunnyWrapper.dll")]
    //internal static extern IntPtr CreateTradeApi();

    //[DllImport("EsunnyWrapper.dll")]
    //internal static extern IntPtr CreateQuoteApi();

    //[DllImport("EsunnyWrapper.dll")]
    //internal static extern IntPtr CreateTradeSpi(EsunnyTradeSpiCallbackStruct callback);

    //[DllImport("EsunnyWrapper.dll")]
    //internal static extern void TradeSetSpi(IntPtr hTrade,IntPtr hSpi);

    //[DllImport("EsunnyWrapper.dll")]
    //internal static extern void TradeFree(IntPtr hTrade);

    //[DllImport("EsunnyWrapper.dll")]
    //internal static extern bool TradeOpen(IntPtr hTrade,TEsAddressField addr);

    //[DllImport("EsunnyWrapper.dll")]
    //internal static extern void TradeClose(IntPtr hTrade);

    //[DllImport("EsunnyWrapper.dll")]
    //internal static extern bool TradeIsOpen(IntPtr hTrade);

    //[DllImport("EsunnyWrapper.dll")]
    //internal static extern int Login(IntPtr hTrade,TEsLoginReqField req);

    //[DllImport("EsunnyWrapper.dll")]
    //internal static extern IntPtr CreateQuoteSpi(EsunnyQuoteSpiCallbackStruct callback);

    [DllImport("EsunnyWrapper.dll")]
     static extern int Process(IntPtr hTrade, EsunnyWrapperAction action, IntPtr req);
    [DllImport("EsunnyWrapper.dll")]
     static extern int Process(IntPtr hTrade, EsunnyWrapperAction action, StringBuilder req);
    [DllImport("EsunnyWrapper.dll")]
    static unsafe extern int Process(IntPtr hTrade, void* action);

    internal static int InvokeAPI(IntPtr handler, EsunnyWrapperAction action, object req)
    {
      IntPtr p = IntPtr.Zero;
      int result = 0;

      if (req != null)
      {

        if (req is IntPtr)
        {
          result = EsunnyWrapper.Process(handler, action, (IntPtr)req);
        }
        else if (req is int)
        {
          result = EsunnyWrapper.Process(handler, action, (IntPtr)(int)req);
        }
        else if (req is StringBuilder)
        {
          result = EsunnyWrapper.Process(handler, action, (StringBuilder)req);
        }
        else
        {
          p = Marshal.AllocHGlobal(Marshal.SizeOf(req));
          Marshal.StructureToPtr(req, p, true);

          result = EsunnyWrapper.Process(handler, action, p);

          Marshal.DestroyStructure(p, req.GetType());
        }
      }
      else
      {
        result = EsunnyWrapper.Process(handler, action, p);
      }

      return result;
    }

  }

  unsafe struct EsunnyWrapperStruct
  {
    ///动作区分
    internal int Action;
	  ///请求参数
    internal void* RequestData;
	  ///请求序号
    internal int nRequestID;
  }

  internal enum EsunnyWrapperAction
  {

    CertEsunnyApi = 0,
    GetEsunnyApiVersion = 1,

    CreateTradeApi = 2,
    CreateQuoteApi = 3,
    CreateTradeSpi = 4,
    CreateQuoteSpi = 5,
    

    //交易基本连接
    TradeSetSpi = 101,
    TradeFree = 102,
    TradeOpen = 103,
    TradeClose = 104,
    TradeIsOpen = 105,

    //行情基本连接
    QuoteSetSpi = 201,
    QuoteFree = 202,
    QuoteOpen = 203,
    QuoteClose = 204,
    QuoteIsOpen = 205,

    //登录
    TradeLogin = 1006,
    TradeSetPass = 1007,
    GetTradingDay = 1008,
    

    //基础信息查询
    QueryExchangeState = 1101,
    QueryCommodity = 1102,
    QueryContract = 1103,
    QueryCmbContract = 1104,

    //交易信息查询
    QueryMoney = 1201,
    QueryOrder = 1202,
    QueryMatch = 1203,
    QueryHold = 1204,

    //交易报单
    OrderInsert = 1301,
    OrderAction = 1302,

    //银期转账
    QueryBankClients = 1401,
    QueryBankCash = 1402,
    BankTrade = 1403,

    QueryClients = 1501,

    SubQuote = 2101,
    SubCombinQuote = 2102
  }
}
