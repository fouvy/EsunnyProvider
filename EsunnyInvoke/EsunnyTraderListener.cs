using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CalmBeltFund.Trading.Esunny
{
  public partial class EsunnyTrader
  {
    /// <summary>
    /// 监听器
    /// </summary>
    class EsunnyTraderListener
    {
      internal EsunnyTrader trader = null;
      IntPtr _instance = IntPtr.Zero;

      internal EsunnyTradeSpiCallbackStruct callbackStruct;


      public IntPtr Instance
      {
        get { return _instance; }
      }

      internal EsunnyTraderListener()
      {

        InitCallbackList();

        //创建回调
        _instance = (IntPtr)EsunnyWrapper.InvokeAPI(IntPtr.Zero, EsunnyWrapperAction.CreateTradeSpi, this.callbackStruct);
      }

      public void OutputString(string msg)
      {
        Trace.WriteLine(msg);
      }


      /// <summary>
      /// 初始化回调结构
      /// </summary>
      void InitCallbackList()
      {

        callbackStruct = new EsunnyTradeSpiCallbackStruct();

        callbackStruct.OpenCallback = new OpenCallback(this.OnOpen);
        callbackStruct.CloseCallback = new CloseCallback(this.OnClose);

        callbackStruct.LoginCallback = new LoginCallback(this.OnLogin);
        callbackStruct.SetPassCallback = new SetPassCallback(this.OnSetPass);

        callbackStruct.QueryMoneyCallback = new QueryMoneyCallback(this.OnQueryMoney);
        callbackStruct.ReturnMoneyCallback = new ReturnMoneyCallback(this.OnReturnMoney);

        callbackStruct.QueryOrderCallback = new QueryOrderCallback(this.OnQueryOrder);
        callbackStruct.ReturnOrderCallback = new ReturnOrderCallback(this.OnReturnOrder);

        callbackStruct.QueryMatchCallback = new QueryMatchCallback(this.OnQueryMatch);
        callbackStruct.ReturnMatchCallback = new ReturnMatchCallback(this.OnReturnMatch);

        callbackStruct.QueryHoldCallback = new QueryHoldCallback(this.OnQueryHold);
        callbackStruct.ReturnHoldCallback = new ReturnHoldCallback(this.OnReturnHold);

        callbackStruct.QueryExchangeStateCallback = new QueryExchangeStateCallback(this.OnQueryExchangeState);
        callbackStruct.ReturnExchangeStateCallback = new ReturnExchangeStateCallback(this.OnReturnExchangeState);

        callbackStruct.QueryCommodityCallback = new QueryCommodityCallback(this.OnQueryCommodity);
        callbackStruct.QueryContractCallback = new QueryContractCallback(this.OnQueryContract);
        callbackStruct.QueryCmbContractCallback = new QueryCmbContractCallback(this.OnQueryCmbContract);

        callbackStruct.QueryClientCallback = new QueryClientCallback(this.OnQueryClient);

        callbackStruct.QueryBankClientCallback = new QueryBankClientCallback(this.OnQueryBankClient);
        callbackStruct.QueryBankCashCallback = new QueryBankCashCallback(this.OnQueryBankCash);
        callbackStruct.ReturnBankCashCallback = new ReturnBankCashCallback(this.OnReturnBankCash);

      }

      internal void OnOpen()
      {
        this.trader.isConnect = true;

        Trace.WriteLine("成功连接到交易服务器！");

        EventProcessor.BeginInvoke(this.trader.OpenResponse, this.trader, new EsunnyEventArgs());
      }


      void OnClose()
      {
        this.trader.isConnect = false;

        Trace.WriteLine("连接中断！");

        EventProcessor.BeginInvoke(this.trader.CloseResponse,this.trader, new EsunnyEventArgs());
      }

      void OnLogin(TEsRspField rsp)
      {

        if (rsp.ErrorCode == 0)
        {
          this.trader.isLogin = true;

          StringBuilder s = new StringBuilder();
          EsunnyWrapper.InvokeAPI(this.trader._instance, EsunnyWrapperAction.GetTradingDay, s);

          Trace.WriteLine("交易日：" + s);
        }
        else
        {
          PInvokeUtility.GetUnicodeString(rsp.ErrorInfo);
          this.trader.isLogin = false;
        }


        EventProcessor.BeginInvoke(this.trader.LoginResponse, this.trader, new EsunnyEventArgs<TEsRspField>(rsp));
      }

      /// <summary>
      /// 修改密码应答
      /// </summary>
      /// <param name="rsp"></param>
      void OnSetPass(TEsRspField rsp)
      {
        EventProcessor.BeginInvoke(this.trader.SetPassResponse, this.trader, new EsunnyEventArgs<TEsRspField>(rsp));
      }

      /// <summary>
      /// 资金查询应答
      /// </summary>
      /// <param name="rsp"></param>
      void OnQueryMoney(TEsMoneyRspField rsp)
      {
        Trace.WriteLine(string.Format("【资金查询应答】{0} : {1} {2}", rsp.TBalance, rsp.TAvailable, rsp.FloatProfit));

        EventProcessor.BeginInvoke(this.trader.QueryMoneyResponse, this.trader, new EsunnyEventArgs<TEsMoneyRspField>(rsp));
      }

      /// <summary>
      /// 资金变化应答
      /// </summary>
      /// <param name="rsp"></param>
      void OnReturnMoney(TEsMoneyRspField rsp)
      {
        Trace.WriteLine(string.Format("【资金变化应答】{0} : {1} {2}", rsp.TBalance, rsp.TAvailable, rsp.FloatProfit));

        EventProcessor.BeginInvoke(this.trader.ReturnMoneyResponse, this.trader, new EsunnyEventArgs<TEsMoneyRspField>(rsp));
      }

      /// <summary>
      /// 委托查询应答
      /// </summary>
      /// <param name="rsp"></param>
      /// <param name="islast"></param>
      void OnQueryOrder(/*TEsOrderInsertRspField*/ IntPtr rsp, bool islast)
      {
        
        if (rsp != IntPtr.Zero)
        {
          TEsOrderInsertRspField data = PInvokeUtility.GetObjectFromIntPtr<TEsOrderInsertRspField>(rsp);
          this.trader.orderList.Add(data);


          Trace.WriteLine(string.Format("【委托查询应答】{0} : {1} {2}", data.ReqData.Contract1, data.OrderNo, data.OrderState));

        }

        if (islast == true)
        {
          EventProcessor.BeginInvoke(this.trader.QueryOrderResponse, this.trader, new EsunnyEventArgs<List<TEsOrderInsertRspField>>(this.trader.orderList));
        }
      }

      /// <summary>
      /// 委托变化应答
      /// </summary>
      /// <param name="rsp"></param>
      void OnReturnOrder(TEsOrderInsertRspField rsp)
      {
        Trace.WriteLine(string.Format("【委托变化应答】{0} : {1} {2}", rsp.ReqData.Contract1, rsp.OrderState, rsp.MatchVol));

        EventProcessor.BeginInvoke(this.trader.ReturnOrderResponse, this.trader, new EsunnyEventArgs<TEsOrderInsertRspField>(rsp));
      }

      /// <summary>
      /// 成交查询应答
      /// </summary>
      /// <param name="rsp"></param>
      /// <param name="islast"></param>
      void OnQueryMatch(/*TEsMatchRspField*/ IntPtr rsp, bool islast)
      {
        if (rsp != IntPtr.Zero)
        {
          TEsMatchRspField data = PInvokeUtility.GetObjectFromIntPtr<TEsMatchRspField>(rsp);
          this.trader.matchList.Add(data);

          Trace.WriteLine(string.Format("【成交查询应答】{0} : {1} {2}", data.Contract, data.MatchPrice, data.MatchVol));

        }

        if (islast == true)
        {
          EventProcessor.BeginInvoke(this.trader.QueryMatchResponse, this.trader, new EsunnyEventArgs<List<TEsMatchRspField>>(this.trader.matchList));
        }
      }


      /// <summary>
      /// 成交变化应答
      /// </summary>
      /// <param name="rsp"></param>
      void OnReturnMatch(TEsMatchRspField rsp)
      {
        Trace.WriteLine(string.Format("【成交查询应答】{0} : {1} {2}", rsp.Contract, rsp.MatchPrice, rsp.MatchVol));
        EventProcessor.BeginInvoke(this.trader.ReturnMatchResponse, this.trader, new EsunnyEventArgs<TEsMatchRspField>(rsp));
      }

      /// <summary>
      /// 持仓查询应答
      /// </summary>
      /// <param name="rsp"></param>
      /// <param name="islast"></param>
      void OnQueryHold(/*TEsHoldRspField*/ IntPtr rsp, bool islast)
      {
        if (rsp != IntPtr.Zero)
        {
          TEsHoldRspField data = PInvokeUtility.GetObjectFromIntPtr<TEsHoldRspField>(rsp);
          this.trader.holdList.Add(data);

          Trace.WriteLine(string.Format("【持仓查询应答】{0} : {1} {2}", data.Contract1, data.HoldPrice, data.HoldVol));
        }

        if (islast == true)
        {
          EventProcessor.BeginInvoke(this.trader.QueryHoldResponse, this.trader, new EsunnyEventArgs<List<TEsHoldRspField>>(this.trader.holdList));
        }
      }


      /// <summary>
      /// 持仓变化应答
      /// </summary>
      /// <param name="rsp"></param>
      void OnReturnHold(TEsHoldRspField rsp)
      {
        Trace.WriteLine(string.Format("【持仓变化应答】{0} : {1} {2}", rsp.Contract1, rsp.HoldPrice, rsp.HoldVol));
        EventProcessor.BeginInvoke(this.trader.ReturnHoldResponse,this.trader, new EsunnyEventArgs<TEsHoldRspField>(rsp));
      }

      /// <summary>
      /// 市场状态查询应答
      /// </summary>
      /// <param name="rsp"></param>
      /// <param name="islast"></param>
      void OnQueryExchangeState(/*TEsExchangeStateRspField*/ IntPtr rsp, bool islast)
      {
        TEsExchangeStateRspField data = PInvokeUtility.GetObjectFromIntPtr<TEsExchangeStateRspField>(rsp);
        this.trader.exchangeStateList.Add(data);

        Trace.WriteLine(string.Format("【市场状态查询应答】{0} : {1} {2}", data.Exchange, data.ExchangeDateTime, data.ExchangeState));

        if (islast == true)
        {
          EventProcessor.BeginInvoke(this.trader.QueryExchangeStateResponse, this.trader, new EsunnyEventArgs<List<TEsExchangeStateRspField>>(this.trader.exchangeStateList));
        }
      }

      /// <summary>
      /// 市场状态变化应答
      /// </summary>
      /// <param name="rsp"></param>
      void OnReturnExchangeState(TEsExchangeStateRspField rsp)
      {
        EventProcessor.BeginInvoke(this.trader.ReturnExchangeStateResponse,this.trader, new EsunnyEventArgs<TEsExchangeStateRspField>(rsp));
      }

      /// <summary>
      /// 商品查询应答
      /// </summary>
      /// <param name="rsp"></param>
      /// <param name="islast"></param>
      void OnQueryCommodity(/*TEsCommodityRspField*/ IntPtr rsp, bool islast)
      {
        if (rsp != IntPtr.Zero)
        {
          TEsCommodityRspField data = PInvokeUtility.GetObjectFromIntPtr<TEsCommodityRspField>(rsp);
          this.trader.commodityList.Add(data);
          

          Trace.WriteLine(string.Format("【商品查询应答】{0} : {1} {2}", data.Exchange, data.Name, data.Commodity));
        }

        if (islast == true)
        {
          EventProcessor.BeginInvoke (this.trader.QueryCommodityResponse,this.trader, new EsunnyEventArgs<List<TEsCommodityRspField>>(this.trader.commodityList));
        }
      }


      /// <summary>
      /// 合约查询应答
      /// </summary>
      /// <param name="rsp"></param>
      /// <param name="islast"></param>
      void OnQueryContract(/*TEsContractRspField*/ IntPtr rsp, bool islast)
      {
        if (rsp != IntPtr.Zero)
        {
          TEsContractRspField data = PInvokeUtility.GetObjectFromIntPtr<TEsContractRspField>(rsp);
          this.trader.contractList.Add(data);
          this.trader.contractMap.Add(data.Contract, data);

          Trace.WriteLine(string.Format("【合约查询应答】{0} : {1} {2}", data.Exchange, data.Name, data.Contract));
        }

        if (islast == true)
        {
          EventProcessor.BeginInvoke(this.trader.QueryContractResponse,this.trader, new EsunnyEventArgs<List<TEsContractRspField>>(this.trader.contractList));
        }
      }


      /// <summary>
      /// 组合合约查询应答
      /// </summary>
      /// <param name="rsp"></param>
      /// <param name="islast"></param>
      void OnQueryCmbContract(/*TEsCmbContractRspField*/ IntPtr rsp, bool islast)
      {
        if (rsp != IntPtr.Zero)
        {
          TEsCmbContractRspField data = PInvokeUtility.GetObjectFromIntPtr<TEsCmbContractRspField>(rsp);
          this.trader.combinContractList.Add(data);

          Trace.WriteLine(string.Format("【组合合约查询应答】{0} : {1} {2}", data.Exchange, data.CmbType, data.Contract1 + "/" + data.Contract2));
        }

        if (islast == true)
        {
          EventProcessor.BeginInvoke(this.trader.QueryCmbContractResponse,this.trader, new EsunnyEventArgs<List<TEsCmbContractRspField>>(this.trader.combinContractList));
        }
      }

      /// <summary>
      /// 交易员下属客户信息查询应答
      /// </summary>
      /// <param name="rsp"></param>
      /// <param name="islast"></param>
      void OnQueryClient(/*TEsClientInfoField*/ IntPtr rsp, bool islast)
      {

      }

      //转账客户查询应答
      void OnQueryBankClient(/*TEsBankClientInfoField*/ IntPtr rsp, bool islast) { }
      //转账流水查询应答
      void OnQueryBankCash(/*TEsBankCashRspField*/ IntPtr rsp, bool islast) { }
      //转账流水变化应答
      void OnReturnBankCash(TEsBankCashRspField rsp) { }

    }
  }
}
