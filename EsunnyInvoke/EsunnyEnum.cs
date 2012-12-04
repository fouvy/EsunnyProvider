using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CalmBeltFund.Trading.Esunny
{
  public enum EsunnyLoginType : byte
  {
    /// <summary>
    /// -单客户
    /// </summary>
    Customer = (byte)'C',
    /// <summary>
    /// -交易员
    /// </summary>
    Trader = (byte)'T'
  }

  /// <summary>
  /// -限价,1-市价
  /// </summary>
  public enum EsunnyOrderType : int
  {
    LimitOrder = 0,
    MarketOrder = 1,
  }

  /// <summary>
  /// 委托状态 
  /// </summary>
  public enum EsunnyOrderStateType : int
  {
    //0-无效单,1-新单,2-已排队,3-完全成交,4-撤单请求,5-已撤单,6-埋单,7-埋单删除,8-已发送,
    //9-待撤,10-部分成交,11-非交易时间,12-资金不足,13-交易关闭,14-指令失败,15-撤单失败,16-系统撤单,
    //17-触发单,18-触发单删除,19-挂起,20-激活,21-已受理,22-自动单,23-自动单删除

    /// <summary>
    /// 无效单
    /// </summary>
    OrderInvalid = 0,
    /// <summary>
    /// 新单
    /// </summary>
    OrderNew = 1,
    /// <summary>
    /// 已排队
    /// </summary>
    OrderInQueue = 2,
    /// <summary>
    /// 完全成交
    /// </summary>
    OrderAllMatch = 3,
    /// <summary>
    /// 撤单请求
    /// </summary>
    OrderInCancel = 4,
    /// <summary>
    /// 已撤单
    /// </summary>
    OrderCanceled = 5,
    /// <summary>
    /// 埋单
    /// </summary>
    OrderCheck = 6,
    /// <summary>
    /// 埋单删除
    /// </summary>
    OrderCheckDelete = 7,
    /// <summary>
    /// 已发送
    /// </summary>
    OrderAlreadySent = 8,
    /// <summary>
    /// 待撤
    /// </summary>
    OrderToCancel = 9,
    /// <summary>
    /// 部分成交
    /// </summary>
    OrderPartMatch = 10,
    /// <summary>
    /// 非交易时间
    /// </summary>
    OrderNonTradingHours = 11,
    /// <summary>
    /// 资金不足
    /// </summary>
    OrderInsufficientFunds = 12,
    /// <summary>
    /// 交易关闭
    /// </summary>
    OrderTradeClosed = 13,
    /// <summary>
    /// 指令失败
    /// </summary>
    OrderInstructFailed = 14,
    /// <summary>
    /// 撤单失败
    /// </summary>
    OrderWithdrawalsFailed = 15,
    /// <summary>
    /// 系统撤单
    /// </summary>
    OrderSystemWithdrawals = 16,
    /// <summary>
    /// 触发单
    /// </summary>
    OrderTriggerOrder = 17,
    /// <summary>
    /// 触发单删除
    /// </summary>
    OrderTriggerOrderDelete = 18,
    /// <summary>
    /// 挂起
    /// </summary>
    OrderSuspend = 19,
    /// <summary>
    /// 激活
    /// </summary>
    OrderActivate = 20,
    /// <summary>
    /// 已受理
    /// </summary>
    OrderAccepted = 21,
    /// <summary>
    /// 自动单
    /// </summary>
    OrderAuto = 22,
    /// <summary>
    /// 自动单删除
    /// </summary>
    OrderAutoDelte = 23
  }

  /// <summary>
  /// 组合类型
  /// </summary>
  public enum EsunnyCombinOrderType : int
  {
    Normal = 0,
    Spread = 1,
    SpreadCommodity = 2
  }

  public enum EsunnyDirectType : byte
  {
    Buy = (byte)'1',
    Sell = (byte)'3'
  }

  public enum EsunnyOffsetType : byte
  {
    Open = (byte)'1',
    CloseToday = (byte)'2',
    Close = (byte)'3'
  }

  public enum EsunnyHedgeType : byte
  {
    [DescriptionAttribute("投机")]
    Speculation = (byte)'1',
    [DescriptionAttribute("套保")]
    Hedge = (byte)'3'
  }

  public enum EsunnySubQuoteType : byte
  {
    订阅 = (byte)'S',
    取消 = (byte)'C'
  }

  /// <summary>
  /// '1'-郑州,'2'-大连,'3'-上海,'5'-中金
  /// </summary>
  public enum EsunnyExchangeType : byte
  {
    CZCE = (byte)'1',
    DCE = (byte)'2',
    SHFE = (byte)'3',
    CFFEX = (byte)'5'
  }

  public enum EsunnyExchangeStateType : byte
  {
    //'0'-系统初始化中,'1'-系统就绪，可以登录,'2'-开盘竞价入单阶段 '3'-开盘集合竞价阶段（停止入单）, '4'-连续交易阶段（开市）,'5'-连续交易暂停阶段 '6'-开盘竞价入单暂停阶段,'7'-收市（闭市）,'8'-断开与交易所连接 

    /// <summary>
    /// 
    /// </summary>
    初始化 = (byte)'0',
    系统就绪 = (byte)'1',
    集合竞价 = (byte)'2',
    竞价撮合 = (byte)'3',
    交易 = (byte)'4',
    休息 = (byte)'5',
    竞价暂停 = (byte)'6',
    收盘 = (byte)'7',
    中断 = (byte)'8',

  }
  
}
