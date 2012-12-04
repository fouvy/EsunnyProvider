using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CalmBeltFund.Trading.Esunny
{
  public class EsunnyQuote
  {
    IntPtr _instance = IntPtr.Zero;
    EsunnyQuoteListener _listener = null;

    private string frontAddress = "";
    private int port = 0;

    bool isConnect = false;
    bool isLogin = false;
    bool isInitialized = false;
    bool isDispose = false;
    bool isSimulationServer = false;



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

    public event EventHandler<EsunnyEventArgs<TEsQuoteRspField>> QuoteResponse;
    public event EventHandler<EsunnyEventArgs<TEsCmbQuoteRspField>> CombinQuoteResponse;

    #endregion

    public void Connect(string frontAddress, int port)
    {
      this.frontAddress = frontAddress;
      this.port = port;

      //创建实例
      this._instance = (IntPtr)EsunnyWrapper.InvokeAPI(IntPtr.Zero, EsunnyWrapperAction.CreateQuoteApi, null);

      //创建监听器
      _listener = new EsunnyQuoteListener();
      _listener._esunnyQuote = this;
      EsunnyWrapper.InvokeAPI(this._instance, EsunnyWrapperAction.QuoteSetSpi, this._listener.Instance);

      //设置行情服务器地址
      TEsAddressField addr = new TEsAddressField();

      addr.Ip = frontAddress;
      addr.Port = port;

      //开始建立连接
      EsunnyWrapper.InvokeAPI(this._instance, EsunnyWrapperAction.QuoteOpen, addr);
    }

    public void SubQuote(TEsQuoteReqField sub)
    {
      //TEsQuoteReqField sub = new TEsQuoteReqField();
      //sub.CmbType = 0;
      //sub.SubQuote = EsunnySubQuoteType.订阅;
      //sub.Exchange = EsunnyExchangeType.CZCE;
      //sub.Contract1 = symbolCode;
      EsunnyWrapper.InvokeAPI(this._instance, EsunnyWrapperAction.SubQuote, sub);
    }


    /// <summary>
    /// 监听器
    /// </summary>
    class EsunnyQuoteListener
    {

      internal EsunnyQuote _esunnyQuote = null;

      IntPtr _instance = IntPtr.Zero;
      internal EsunnyQuoteSpiCallbackStruct callbackStruct;


      public IntPtr Instance
      {
        get { return _instance; }
      }

      internal EsunnyQuoteListener()
      {

        InitCallbackList();

        _instance = (IntPtr)EsunnyWrapper.InvokeAPI(IntPtr.Zero, EsunnyWrapperAction.CreateQuoteSpi, this.callbackStruct);
      }

      /// <summary>
      /// 初始化回调结构
      /// </summary>
      void InitCallbackList()
      {
        callbackStruct = new EsunnyQuoteSpiCallbackStruct();

        callbackStruct.OpenCallback = new OpenCallback(this.OnOpen);
        callbackStruct.CloseCallback = new CloseCallback(this.OnClose);
        callbackStruct.QuoteCallback = new QuoteCallback(this.OnQuote);
        callbackStruct.CombinQuoteCallback = new CombinQuoteCallback(this.OnCombinQuote);

      }

      internal void OnOpen()
      {
        this._esunnyQuote.isConnect = true;

        Trace.WriteLine("成功连接到行情服务器！");

        EventProcessor.BeginInvoke(this._esunnyQuote.OpenResponse, this._esunnyQuote, new EsunnyEventArgs());
      }


      void OnClose()
      {
        this._esunnyQuote.isConnect = false;

        Trace.WriteLine("行情连接中断！");

        EventProcessor.BeginInvoke(this._esunnyQuote.CloseResponse, this._esunnyQuote, new EsunnyEventArgs());
      }

      void OnQuote(TEsQuoteRspField rsp)
      {
        Trace.WriteLine(string.Format("行情：{0} {1}", rsp.Contract, rsp.New));
        EventProcessor.BeginInvoke(this._esunnyQuote.QuoteResponse, this._esunnyQuote, new EsunnyEventArgs<TEsQuoteRspField>(rsp));
      }

      void OnCombinQuote(TEsCmbQuoteRspField rsp)
      {
        EventProcessor.BeginInvoke(this._esunnyQuote.CombinQuoteResponse, this._esunnyQuote, new EsunnyEventArgs<TEsCmbQuoteRspField>(rsp));
      }
    }
  }


  
   
}
