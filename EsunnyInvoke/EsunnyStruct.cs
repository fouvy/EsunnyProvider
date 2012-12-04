using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace CalmBeltFund.Trading.Esunny
{

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsAddressField
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Ip;
    public int Port;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsRspField
  {
    public int ErrorCode;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 51)]
    public byte[] ErrorInfo;

    public string ErrorMessage
    {
      get { return PInvokeUtility.GetUnicodeString(this.ErrorInfo).TrimEnd('\0'); }
    }
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsLoginReqField
  {
    public EsunnyLoginType LoginType; //'C'-单客户,'T'-交易员
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string LoginNo;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Password;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsSetPassReqField
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string OldPassword;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string NewPassword;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsClientInfoField
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string ClientNo;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string ClientName;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsBankClientInfoField
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string GroupNo;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string ClientNo;
    public byte BankId;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string BankClientNo;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string PersonId;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string PersonName;
    public byte State;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsBankCashReqField
  {
    TEsBankClientInfoField BankClient;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string BankPassword;//银行密码
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string FuturePassword;//期货密码
    public byte TradeType;//转账类型
    public double Money;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsBankCashRspField
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string ClientNo;//期货帐号
    public byte BankId;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string BankClientNo;//银行帐号
    public byte PackFlag;//发起类型
    public int TrTradeType;//交易类型
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
    public string BankSerNo;//银行流水号
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
    public string FutureSerNo;//期货流水号
    public double Money;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string OperNo;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string DateTime;//操作时间
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
    public string RetCode;//返回码  ErrorCode.dat文件
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsMoneyRspField
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string ClientNo;//客户号
    public double YAvailable;//昨可用资金
    public double YMoney;//昨账面资金
    public double YBalance;//昨资金权益
    public double CashOut;//出金
    public double CashIn;//入金
    public double Fee;//手续费
    public double Deposit;//保证金
    public double Frozen;//冻结保证金
    public double CoverProfit;//平仓盈亏(逐笔)
    public double FloatProfit;//持仓盈亏(逐笔)
    public double DayCoverProfit;//平仓盈亏(盯市)
    public double DayFloatProfit;//持仓盈亏(盯市)
    public double TAvailable;//今可用资金
    public double TMoney;//今账面资金
    public double TBalance;//今资金权益
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsOrderInsertReqField
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string ClientNo;//客户号
    public int RequestID;
    public EsunnyOrderType OrderType;
    public EsunnyExchangeType Exchange;
    public EsunnyCombinOrderType CmbType;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Contract1;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Contract2;
    public EsunnyDirectType Direct;
    public EsunnyOffsetType Offset;
    public EsunnyHedgeType Hedge;
    public double OrderPrice;
    public int OrderVol;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsOrderInsertRspField
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string ClientNo;//客户号
    public TEsOrderInsertReqField ReqData;
    public TEsRspField RspHead;
    public EsunnyOrderStateType OrderState;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string OrderNo;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string LocalNo;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string SystemNo;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string MemberNo;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string PosNo;
    public double MatchPrice;//暂时无用
    public int MatchVol;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string InsertTime;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string DeleteTime;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string InsertNo;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string DeleteNo;
    public int StreamID;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
    public string OrderEcho;//上级系统错误信息提示
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsOrderActionReqField
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string ClientNo;//客户号
    public EsunnyExchangeType Exchange;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Contract;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string OrderNo;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string SystemNo;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsMatchRspField
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string ClientNo;//客户号
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string LocalNo;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string SystemNo;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string MatchNo;
    public EsunnyExchangeType Exchange;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Contract;
    public EsunnyDirectType Direct;
    public EsunnyOffsetType Offset;
    public EsunnyHedgeType Hedge;
    public double MatchPrice;
    public int MatchVol;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
    public string MatchTime;
    public double Fee;
    public int StreamID;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsHoldRspField
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string ClientNo;//客户号
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string MatchNo;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string CmbMatchNo;
    public EsunnyExchangeType Exchange;
    public EsunnyCombinOrderType CmbType;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Contract1;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Contract2;
    public EsunnyDirectType Direct;
    public EsunnyHedgeType Hedge;
    public double HoldPrice;
    public int HoldVol;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
    public string HoldDate;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsExchangeStateRspField
  {
    public EsunnyExchangeType Exchange;
    public EsunnyExchangeStateType ExchangeState;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string ExchangeDateTime;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsCommodityRspField
  {
    public EsunnyExchangeType Exchange;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Commodity;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Name;
    /// <summary>
    /// 合约乘数
    /// </summary>
    public int Dot;
    /// <summary>
    /// 
    /// </summary>
    public double Tick;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsContractRspField
  {
    public EsunnyExchangeType Exchange;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Contract;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Name;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
    public string BeginTradeDay;//开始交易日  以下三个字段数据尚不正确
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
    public string EndTradeDay;//结束交易日
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
    public string DeliveryDay;//交割日
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsCmbContractRspField
  {
    public EsunnyExchangeType Exchange;
    public EsunnyCombinOrderType CmbType;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Contract1;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Contract2;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsQuoteReqField
  {
    public EsunnyExchangeType Exchange;
    public EsunnyCombinOrderType CmbType;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Contract1;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Contract2;
    public EsunnySubQuoteType SubQuote;
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsQuoteRspField
  {
    public EsunnyExchangeType Exchange;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Contract;

    public double YClose;//昨收盘
    public double YSettle;//昨结算
    public double Open;//开盘价
    public double High;//最高价
    public double Low;//最低价
    public double New;//最新价
    public double Settle;//结算价
    public double AvgPrice;//平均价
    public int Volume;//成交量
    public int Amount;//持仓量

    public double Buy;//申买价
    public int BuyVol;//申买量
    public double Sell;//申卖价
    public int SellVol;//申卖量

    public double LimitUp;//涨停板
    public double LimitDown;//跌停板
  }

  [StructLayout(LayoutKind.Sequential)]
  public struct TEsCmbQuoteRspField
  {
    public EsunnyExchangeType Exchange;
    public EsunnyCombinOrderType CmbType;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Contract1;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
    public string Contract2;

    //郑州大连均发布以下4字段
    public double Buy;//申买价
    public int BuyVol;//申买量
    public double Sell;//申卖价
    public int SellVol;//申卖量

    //郑州发布以下2字段
    public int AllBuyVol;//总买量
    public int AllSellVol;//总卖量

    //易盛根据组合行情 派生计算
    public double DeriveBuy;//申买价
    public int DeriveBuyVol;//申买量
    public double DeriveSell;//
    public int DeriveSellVol;//申卖量

  }
}
