using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CalmBeltFund.Trading.Esunny
{

  internal delegate void OpenCallback();
  internal delegate void CloseCallback();

  internal delegate void LoginCallback(TEsRspField rsp);
  internal delegate void SetPassCallback(TEsRspField rsp);

  //资金查询应答
  internal delegate void QueryMoneyCallback(TEsMoneyRspField rsp);
  //资金变化应答
  internal delegate void ReturnMoneyCallback(TEsMoneyRspField rsp);

  //委托查询应答
  internal delegate void QueryOrderCallback(/*TEsOrderInsertRspField*/ IntPtr rsp, [MarshalAs(UnmanagedType.U1)]bool islast);
  //委托变化应答
  internal delegate void ReturnOrderCallback(TEsOrderInsertRspField rsp);

  //成交查询应答
  internal delegate void QueryMatchCallback(/*TEsMatchRspField*/ IntPtr rsp, [MarshalAs(UnmanagedType.U1)]bool islast);
  //成交变化应答
  internal delegate void ReturnMatchCallback(TEsMatchRspField rsp);

  //持仓查询应答
  internal delegate void QueryHoldCallback(/*TEsHoldRspField*/ IntPtr rsp, [MarshalAs(UnmanagedType.U1)]bool islast);
  //持仓变化应答
  internal delegate void ReturnHoldCallback(TEsHoldRspField rsp);

  //市场状态查询应答
  internal delegate void QueryExchangeStateCallback(/*TEsExchangeStateRspField*/ IntPtr rsp, [MarshalAs(UnmanagedType.U1)]bool islast);
  //市场状态变化应答
  internal delegate void ReturnExchangeStateCallback(TEsExchangeStateRspField rsp);

  //商品查询应答
  internal delegate void QueryCommodityCallback(/*TEsCommodityRspField*/ IntPtr rsp, [MarshalAs(UnmanagedType.U1)]bool islast);
  //合约查询应答
  internal delegate void QueryContractCallback(/*TEsContractRspField*/ IntPtr rsp, [MarshalAs(UnmanagedType.U1)]bool islast);
  //组合合约查询应答
  internal delegate void QueryCmbContractCallback(/*TEsCmbContractRspField*/ IntPtr rsp, [MarshalAs(UnmanagedType.U1)]bool islast);

  //交易员下属客户信息查询应答
  internal delegate void QueryClientCallback(/*TEsClientInfoField*/ IntPtr rsp, [MarshalAs(UnmanagedType.U1)]bool islast);

  //转账客户查询应答
  internal delegate void QueryBankClientCallback(/*TEsBankClientInfoField*/ IntPtr rsp, [MarshalAs(UnmanagedType.U1)]bool islast);
  //转账流水查询应答
  internal delegate void QueryBankCashCallback(/*TEsBankCashRspField*/ IntPtr rsp, [MarshalAs(UnmanagedType.U1)]bool islast);
  //转账流水变化应答
  internal delegate void ReturnBankCashCallback(TEsBankCashRspField rsp);


  //单腿行情数据
  internal delegate void QuoteCallback(TEsQuoteRspField rsp);
  //组合行情数据
  internal delegate void CombinQuoteCallback(TEsCmbQuoteRspField rsp);


  /// <summary>
  /// 回调函数指针结构
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  internal struct EsunnyTradeSpiCallbackStruct
  {
    internal OpenCallback OpenCallback;
    internal CloseCallback CloseCallback;

    internal LoginCallback LoginCallback;
    internal SetPassCallback SetPassCallback;

    //资金查询应答	
    internal QueryMoneyCallback QueryMoneyCallback;
    //资金变化应答	
    internal ReturnMoneyCallback ReturnMoneyCallback;

    //委托查询应答	
    internal QueryOrderCallback QueryOrderCallback;
    //委托变化应答	
    internal ReturnOrderCallback ReturnOrderCallback;

    //成交查询应答	
    internal QueryMatchCallback QueryMatchCallback;
    //成交变化应答	
    internal ReturnMatchCallback ReturnMatchCallback;

    //持仓查询应答	
    internal QueryHoldCallback QueryHoldCallback;
    //持仓变化应答	
    internal ReturnHoldCallback ReturnHoldCallback;

    //市场状态查询应答	
    internal QueryExchangeStateCallback QueryExchangeStateCallback;
    //市场状态变化应答	
    internal ReturnExchangeStateCallback ReturnExchangeStateCallback;

    //商品查询应答	
    internal QueryCommodityCallback QueryCommodityCallback;
    //合约查询应答	
    internal QueryContractCallback QueryContractCallback;
    //组合合约查询应答	
    internal QueryCmbContractCallback QueryCmbContractCallback;

    //交易员下属客户信息查询应答	
    internal QueryClientCallback QueryClientCallback;

    //转账客户查询应答	
    internal QueryBankClientCallback QueryBankClientCallback;
    //转账流水查询应答	
    internal QueryBankCashCallback QueryBankCashCallback;
    //转账流水变化应答	
    internal ReturnBankCashCallback ReturnBankCashCallback;

  }


  /// <summary>
  /// 行情回调函数指针结构
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  internal struct EsunnyQuoteSpiCallbackStruct
  {
    internal OpenCallback OpenCallback;
    internal CloseCallback CloseCallback;
    internal QuoteCallback QuoteCallback;
    internal CombinQuoteCallback CombinQuoteCallback;
  }

}
