using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace CalmBeltFund.Trading.Esunny
{
  public partial class EsunnyTrader : Component, IDisposable
  {

    IntPtr _instance = IntPtr.Zero;
    EsunnyTraderListener _listener = null;
    int _requestID = 0;

    private string frontAddress = "";
    private string brokerID = "";
    private string userID = "";
    private string password = "";

    bool isConnect = false;
    bool isLogin = false;
    bool isSettlementConfim = false;
    bool isInitialized = false;
    bool isDispose = false;
    bool isSimulationServer = false;

    List<TEsOrderInsertRspField> orderList = new List<TEsOrderInsertRspField>();
    List<TEsMatchRspField> matchList = new List<TEsMatchRspField>();
    List<TEsHoldRspField> holdList = new List<TEsHoldRspField>();
    List<TEsExchangeStateRspField> exchangeStateList = new List<TEsExchangeStateRspField>();

    List<TEsCommodityRspField> commodityList = new List<TEsCommodityRspField>();
    
    List<TEsContractRspField> contractList = new List<TEsContractRspField>();
    Dictionary<string, TEsContractRspField> contractMap = new Dictionary<string, TEsContractRspField>();

    List<TEsCmbContractRspField> combinContractList = new List<TEsCmbContractRspField>();
    Dictionary<string, TEsCmbContractRspField> combinContractMap = new Dictionary<string, TEsCmbContractRspField>();


    /// <summary>
    /// 是否已连接
    /// </summary>
    public bool IsConnect
    {
      get { return isConnect; }
    }

    /// <summary>
    /// 是否已登录
    /// </summary>
    public bool IsLogin
    {
      get { return isLogin; }
    }

    /// <summary>
    /// 是否已初始化
    /// </summary>
    public bool IsInitialized
    {
      get { return isInitialized; }
    }

    /// <summary>
    /// 是否是模拟服务器
    /// </summary>
    public bool IsSimulationServer
    {
      get { return isSimulationServer; }
    }

    #region Events

    public event EventHandler<EsunnyEventArgs> OpenResponse;
    public event EventHandler<EsunnyEventArgs> CloseResponse;

    public event EventHandler<EsunnyEventArgs<TEsRspField>> LoginResponse;
    public event EventHandler<EsunnyEventArgs<TEsRspField>> SetPassResponse;

    //资金查询应答
    public event EventHandler<EsunnyEventArgs<TEsMoneyRspField>> QueryMoneyResponse;
    //资金变化应答
    public event EventHandler<EsunnyEventArgs<TEsMoneyRspField>> ReturnMoneyResponse;

    //委托查询应答
    public event EventHandler<EsunnyEventArgs<List<TEsOrderInsertRspField>>> QueryOrderResponse;
    //委托变化应答
    public event EventHandler<EsunnyEventArgs<TEsOrderInsertRspField>> ReturnOrderResponse;

    //成交查询应答
    public event EventHandler<EsunnyEventArgs<List<TEsMatchRspField>>> QueryMatchResponse;
    //成交变化应答
    public event EventHandler<EsunnyEventArgs<TEsMatchRspField>> ReturnMatchResponse;

    //持仓查询应答
    public event EventHandler<EsunnyEventArgs<List<TEsHoldRspField>>> QueryHoldResponse;
    //持仓变化应答
    public event EventHandler<EsunnyEventArgs<TEsHoldRspField>> ReturnHoldResponse;

    //市场状态查询应答
    public event EventHandler<EsunnyEventArgs<List<TEsExchangeStateRspField>>> QueryExchangeStateResponse;
    //市场状态变化应答
    public event EventHandler<EsunnyEventArgs<TEsExchangeStateRspField>> ReturnExchangeStateResponse;

    //商品查询应答
    public event EventHandler<EsunnyEventArgs<List<TEsCommodityRspField>>> QueryCommodityResponse;
    //合约查询应答
    public event EventHandler<EsunnyEventArgs<List<TEsContractRspField>>> QueryContractResponse;
    //组合合约查询应答
    public event EventHandler<EsunnyEventArgs<List<TEsCmbContractRspField>>> QueryCmbContractResponse;

    //交易员下属客户信息查询应答
    public event EventHandler<EsunnyEventArgs<List<TEsClientInfoField>>> QueryClientResponse;

    //转账客户查询应答
    public event EventHandler<EsunnyEventArgs<List<TEsBankClientInfoField>>> QueryBankClientResponse;
    //转账流水查询应答
    public event EventHandler<EsunnyEventArgs<TEsBankCashRspField>> QueryBankCashResponse;
    //转账流水变化应答
    public event EventHandler<EsunnyEventArgs<TEsBankCashRspField>> ReturnBankCashResponse;


    #endregion


    public EsunnyTrader()
    {

      StringBuilder builder = new StringBuilder();

      builder.Append("4A35B623174363F3A1BDD4D66D1F66AC7A368C423BB68CAFD0C78CDBA812DAAD9AAD1C1052E60447B35F0E2237A83160554F");

      int cert = EsunnyWrapper.InvokeAPI(IntPtr.Zero, EsunnyWrapperAction.CertEsunnyApi, builder);

      if (cert == 0)
      {
        throw new LicenseException(typeof(EsunnyTrader));
      }

      builder = new StringBuilder(50);
      EsunnyWrapper.InvokeAPI(IntPtr.Zero, EsunnyWrapperAction.GetEsunnyApiVersion, builder);

      string ver = builder.ToString();
      Trace.WriteLine(ver);

    }

    public void Connect(string frontAddress, int port, string userID, string password)
    {

      this.userID = userID;
      this.password = password;


      //this._instance = EsunnyWrapper.CreateTradeApi();
      this._instance = (IntPtr)EsunnyWrapper.InvokeAPI(IntPtr.Zero, EsunnyWrapperAction.CreateTradeApi, null);

      //监听器
      _listener = new EsunnyTraderListener();
      _listener.trader = this;
      EsunnyWrapper.InvokeAPI(this._instance, EsunnyWrapperAction.TradeSetSpi, this._listener.Instance);

      TEsAddressField addr = new TEsAddressField();

      addr.Ip = frontAddress;
      addr.Port = port;

      EsunnyWrapper.InvokeAPI(this._instance, EsunnyWrapperAction.TradeOpen, addr);
    }

    public void Login()
    {
      TEsLoginReqField req = new TEsLoginReqField();

      req.LoginType = EsunnyLoginType.Customer;
      req.LoginNo = this.userID;
      req.Password = this.password;

      //EsunnyWrapper.Login(this._instance, req);


      InvokeAPI(EsunnyWrapperAction.TradeLogin, req);
    }

    public DateTime GetTradingDate()
    {
      StringBuilder builder = new StringBuilder();

      int ret = InvokeAPI(EsunnyWrapperAction.GetTradingDay, builder);

      if (ret == 0)
      {
        return DateTime.ParseExact(builder.ToString(), "yyyy-MM-dd", null);
      }
      else
      {
        return DateTime.MinValue;
      }
    }

    /// <summary>
    /// 查询交易所状态
    /// </summary>
    public void QueryExchangeState()
    {
      this.exchangeStateList.Clear();

      int ret = InvokeAPI(EsunnyWrapperAction.QueryExchangeState, null);

      if (ret != 0)
      {
        throw new ApplicationException("请求失败：查询交易所状态");
      }
    }

    /// <summary>
    /// 查询商品
    /// </summary>
    public void QueryCommodity()
    {
      this.commodityList.Clear();

      int ret = InvokeAPI(EsunnyWrapperAction.QueryCommodity, null);

      if (ret != 0)
      {
        throw new ApplicationException("请求失败：查询商品");
      }
    }

    /// <summary>
    /// 查询合约
    /// </summary>
    public void QueryContract()
    {
      this.contractList.Clear();

      InvokeAPI(EsunnyWrapperAction.QueryContract, null);
    }

    /// <summary>
    /// 查询组合合约
    /// </summary>
    public void QueryCmbContract()
    {
      this.combinContractList.Clear();

      InvokeAPI(EsunnyWrapperAction.QueryCmbContract, null);
    }

    /// <summary>
    /// 查询账户资金
    /// </summary>
    public void QueryMoney()
    {
      InvokeAPI(EsunnyWrapperAction.QueryMoney, null);
    }
    
    /// <summary>
    /// 查询报单
    /// </summary>
    public void QueryOrder()
    {
      this.orderList.Clear();

      InvokeAPI(EsunnyWrapperAction.QueryOrder, 0);
    }

    /// <summary>
    /// 查询成交
    /// </summary>
    public void QueryTrade()
    {
      this.matchList.Clear();

      InvokeAPI(EsunnyWrapperAction.QueryMatch, 0);
    }

    /// <summary>
    /// 查询持仓
    /// </summary>
    public void QueryPosition()
    {
      this.holdList.Clear();

      InvokeAPI(EsunnyWrapperAction.QueryHold, null);
    }

    public TEsOrderInsertReqField InsertOrder(string symbolCode, double price, EsunnyDirectType direction, EsunnyOffsetType offset, int volume)
    {

      TEsOrderInsertReqField req = new TEsOrderInsertReqField();


      if (this.contractMap.ContainsKey(symbolCode))
      {
        //交易所
        req.Exchange = contractMap[symbolCode].Exchange;
        //普通单
        req.CmbType = EsunnyCombinOrderType.Normal;
        req.Contract1 = symbolCode.ToUpper();
      }
      else if (this.combinContractMap.ContainsKey(symbolCode))
      {
        //交易所
        req.Exchange = combinContractMap[symbolCode].Exchange;
        //跨期/跨品种
        req.CmbType = combinContractMap[symbolCode].CmbType;

        string[] items = symbolCode.Split('\\');

        req.Contract1 = items[0];
        req.Contract2 = items[1];

      }
      else
      {
        throw new ApplicationException("未知合约：" + symbolCode);
      }

      req.Direct = direction;
      req.Offset = offset;
      req.OrderPrice = price;
      req.OrderVol = volume;
      req.RequestID = this._requestID++;

      req.OrderType = EsunnyOrderType.LimitOrder;
      req.Hedge = EsunnyHedgeType.Speculation;

      InvokeAPI(EsunnyWrapperAction.OrderInsert, req);

      return req;
    }

    //public TEsOrderInsertReqField InsertOrder(TradingOrderParameter parameter)
    //{
    //  Symbol symbol = parameter.Symbol;

    //  TEsOrderInsertReqField req = new TEsOrderInsertReqField();

    //  if (symbol.IsCustomCombinSymbol)
    //  {

    //  }
    //  else
    //  {

    //    if (symbol.Market != null)
    //    {
    //      //交易所
    //      req.Exchange = EsunnyConvert.ConvertToEsunny(symbol.Market.MarketCode);
    //    }

    //    if (symbol.SymbolType == SymbolType.CommoditiesSpreadFutures)
    //    {
    //      CombinSymbol combinSymbol = symbol as CombinSymbol;

    //      if (combinSymbol.Items[0].SymbolBlock.BlockCode == combinSymbol.Items[1].SymbolBlock.BlockCode)
    //      {
    //        //跨期
    //        req.CmbType = EsunnyCombinOrderType.Spread;
    //      }
    //      else
    //      {
    //        //跨商品
    //        req.CmbType = EsunnyCombinOrderType.SpreadCommodity;
    //      }

    //      req.Contract1 = combinSymbol.Items[0].ExchangeSymbolCode.ToUpper();
    //      req.Contract2 = combinSymbol.Items[1].ExchangeSymbolCode.ToUpper();
    //    }
    //    else
    //    {
    //      //普通单
    //      req.CmbType = EsunnyCombinOrderType.Normal;
    //      req.Contract1 = symbol.ExchangeSymbolCode.ToUpper();
    //    }


    //    req.Direct = EsunnyConvert.ConvertToEsunny(parameter.Direction);
    //    req.Offset = EsunnyConvert.ConvertToEsunny(parameter.Offset);
    //    req.OrderPrice = Convert.ToDouble(parameter.Price);
    //    req.OrderVol = Convert.ToInt32(parameter.Volume);
    //    req.RequestID = this._requestID++;
        
    //    req.OrderType = EsunnyOrderType.LimitOrder;
    //    req.Hedge = EsunnyHedgeType.Speculation;

    //    InvokeAPI(EsunnyWrapperAction.OrderInsert, req);
    //  }

    //  return req;
    //}


    int InvokeAPI(EsunnyWrapperAction action, object req)
    {
      return EsunnyWrapper.InvokeAPI(this._instance, action, req);

      //IntPtr p = IntPtr.Zero;

      //if (req != null)
      //{
      //  p = Marshal.AllocHGlobal(Marshal.SizeOf(req));

      //  Marshal.StructureToPtr(req, p, true);
      //}

      //int result = EsunnyWrapper.Process(this._instance, action, p);

      //if (req != null)
      //{
      //  Marshal.DestroyStructure(p, req.GetType());
      //}
    }

  }
}
