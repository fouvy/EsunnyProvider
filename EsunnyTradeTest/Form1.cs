using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CalmBeltFund.Trading.Esunny;
using System.Threading;
using CalmBeltFund.Trading;
using CalmBeltFund.Trading.Data;

namespace EsunnyTradeTest
{
  public partial class Form1 : Form
  {

    EsunnyTrader trader = new EsunnyTrader();
    EsunnyQuote quote = new EsunnyQuote();
    EventHandler<EsunnyEventArgs<List<TEsCommodityRspField>>> queryCommodityResponse = null;

    EventHandler<EsunnyEventArgs<List<TEsContractRspField>>> queryContractResponse = null;

    EventHandler<EsunnyEventArgs<List<TEsOrderInsertRspField>>> queryOrderResponse = null;
    EventHandler<EsunnyEventArgs<TEsMoneyRspField>> queryMoneyResponse = null;
    EventHandler<EsunnyEventArgs<List<TEsExchangeStateRspField>>> queryExchangeStateResponse = null;


    BindingList<EsunnyInputOrder> orders = new BindingList<EsunnyInputOrder>();

    public Form1()
    {
      InitializeComponent();

      this.idOrderDataGridView.AutoGenerateColumns = true;

      queryCommodityResponse = new EventHandler<EsunnyEventArgs<List<TEsCommodityRspField>>>(trader_QueryCommodityResponse);
      queryContractResponse += new EventHandler<EsunnyEventArgs<List<TEsContractRspField>>>(trader_QueryContractResponse);
      queryOrderResponse= new EventHandler<EsunnyEventArgs<List<TEsOrderInsertRspField>>>(trader_QueryOrderResponse);
      queryMoneyResponse = new EventHandler<EsunnyEventArgs<TEsMoneyRspField>>(trader_QueryMoneyResponse);
      queryExchangeStateResponse = new EventHandler<EsunnyEventArgs<List<TEsExchangeStateRspField>>>(trader_QueryExchangeStateResponse);

      trader.QueryCommodityResponse += queryCommodityResponse;
      trader.QueryContractResponse += queryContractResponse;
      trader.QueryCmbContractResponse += new EventHandler<EsunnyEventArgs<List<TEsCmbContractRspField>>>(trader_QueryCmbContractResponse);
      trader.QueryOrderResponse += queryOrderResponse;
      trader.QueryMoneyResponse += queryMoneyResponse;
      trader.QueryExchangeStateResponse += queryExchangeStateResponse;
      trader.ReturnOrderResponse += new EventHandler<EsunnyEventArgs<TEsOrderInsertRspField>>(trader_ReturnOrderResponse);


      quote.QuoteResponse += new EventHandler<EsunnyEventArgs<TEsQuoteRspField>>(quote_QuoteResponse);
    }

    void trader_ReturnOrderResponse(object sender, EsunnyEventArgs<TEsOrderInsertRspField> e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          EsunnyInputOrder order = EsunnyConvert.ConvertOrder(e.Value);

          int i = orders.IndexOf(order);

          if (i < 0)
          {
            orders.Add(order);
          }
          else
          {
            EsunnyInputOrder data = orders[i];

            data.OrderTradeStatus = order.OrderTradeStatus;
            data.TradeVolume = order.TradeVolume;
            data.Message = order.Message;

            orders.ResetItem(i);
          }
        }));
      }
    }

    void quote_QuoteResponse(object sender, EsunnyEventArgs<TEsQuoteRspField> e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          Log(string.Format("{0} : {1} {2} {3}", e.Value.Exchange, e.Value.Contract, e.Value.Buy, e.Value.Sell));
        }));
      }
    }

    void trader_QueryCmbContractResponse(object sender, EsunnyEventArgs<List<TEsCmbContractRspField>> e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          foreach (var item in e.Value)
          {
            Log(string.Format("{0} : {1} {2} {3}", item.Exchange, item.CmbType, item.Contract1, item.Contract2));
          }
        }));
      }
      else
      {

        foreach (var item in e.Value)
        {
          Log(string.Format("{0} : {1} {2} {3}", item.Exchange, item.CmbType, item.Contract1, item.Contract2));
        }
      }
    }

    void trader_QueryContractResponse(object sender, EsunnyEventArgs<List<TEsContractRspField>> e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(queryContractResponse, sender, e);
      }
      else
      {

        foreach (var item in e.Value)
        {
          Log(string.Format("{0} : {1} {2} {3}", item.Exchange, item.Name, item.Contract, item.EndTradeDay));

          this.symbolCodeComboBox1.Properties.Items.Add(item);
        }

        
      }
    }

    void trader_QueryExchangeStateResponse(object sender, EsunnyEventArgs<List<TEsExchangeStateRspField>> e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(queryExchangeStateResponse, sender, e);
      }
      else
      {
        StringBuilder buffer = new StringBuilder();

        foreach (var item in e.Value)
        {
          buffer.AppendFormat("{0}:{1} ",item.Exchange,item.ExchangeState);
        }

        Log(buffer.ToString());
      }
    }

    void trader_QueryMoneyResponse(object sender, EsunnyEventArgs<TEsMoneyRspField> e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(queryMoneyResponse, sender, e);
      }
      else
      {
        this.idOrderBindingSource.DataSource = e.Value;
      }
    }

    void trader_QueryOrderResponse(object sender, EsunnyEventArgs<List<TEsOrderInsertRspField>> e)
    {

      if (this.InvokeRequired)
      {
        this.Invoke(queryOrderResponse, sender, e);
      }
      else
      {

        

        foreach (var item in e.Value)
        {
          EsunnyInputOrder order = EsunnyConvert.ConvertOrder(item);

          int i =orders.IndexOf(order);

          if (i < 0)
          {
            orders.Add(order);
          }
          else
          {
            EsunnyInputOrder data = orders[i];

            data.OrderTradeStatus = order.OrderTradeStatus;
            data.TradeVolume = order.TradeVolume;
            data.Message = order.Message;

            orders.ResetItem(i);
          }
        }
        
      }
    }

    void trader_QueryCommodityResponse(object sender, EsunnyEventArgs<List<TEsCommodityRspField>> e)
    {

      if (this.InvokeRequired)
      {
        this.Invoke(queryCommodityResponse, sender, e);
      }
      else
      {

        foreach (var item in e.Value)
        {
          Log(string.Format("{0} : {1} {2} {3}", item.Exchange, item.Name, item.Commodity, item.Dot));
        }
      }
    }

    private void idQuerySymbolButton_Click(object sender, EventArgs e)
    {
      trader.QueryExchangeState();
      Thread.Sleep(500);
      trader.QueryContract();
      Thread.Sleep(500);
      trader.QueryCmbContract();
      Thread.Sleep(500);
      trader.QueryCommodity();
    }

    void Log(string s)
    {
      this.toolStripStatusLabel1.Text = s;
    }

    private void idLoginMenuItem_Click(object sender, EventArgs e)
    {
      trader.Connect("222.88.40.170", 6060, "Q12781469", "745641");

      while (trader.IsConnect == false)
      {
        Log("正在连接");
        Thread.Sleep(500);
      }

      Log("连接成功");

      trader.Login();

      while (trader.IsLogin == false)
      {
        Log("正在登录");
        Thread.Sleep(500);
      }

      Log("登录成功");

      quote.Connect("123.15.58.21", 6161);

      Log("连接行情");

      while (quote.IsConnect == false)
      {
        Log("正在登录行情");
        Thread.Sleep(500);
      }

      //quote.SubQuote("SR201");

      trader.QueryExchangeState();

      Thread.Sleep(2000);
      trader.QueryCommodity();
      Thread.Sleep(2000);
      trader.QueryContract();
      Thread.Sleep(2000);
      trader.QueryCmbContract();

    }

    private void idTradeQueryOrderMenuItem_Click(object sender, EventArgs e)
    {
      trader.QueryOrder();
    }

    private void idTradeQueryAmountMenuItem_Click(object sender, EventArgs e)
    {
      trader.QueryMoney();
    }


    private void idTradeQueryPositionMenuItem_Click(object sender, EventArgs e)
    {
      trader.QueryPosition();
    }

    private void idSendOrderButton_Click(object sender, EventArgs e)
    {
      if (symbolCodeComboBox1.SelectedItem != null)
      {
        TEsContractRspField field = (TEsContractRspField)symbolCodeComboBox1.SelectedItem;

        trader.InsertOrder(field.Contract, Convert.ToDouble(idPriceNumericUpDown.Value), EsunnyDirectType.Buy, EsunnyOffsetType.Open, 1);

      }

     
    }

    private void Form1_Load(object sender, EventArgs e)
    {

      this.idOrderBindingSource.DataSource = orders;
    }

    private void symbolCodeComboBox1_SelectedValueChanged(object sender, EventArgs e)
    {

      if (symbolCodeComboBox1.SelectedItem != null)
      {
        TEsContractRspField field = (TEsContractRspField)symbolCodeComboBox1.SelectedItem;
        
        TEsQuoteReqField req = new TEsQuoteReqField();
        req.Exchange = field.Exchange;
        req.CmbType = EsunnyCombinOrderType.Normal;
        req.Contract1 = field.Contract;
        req.SubQuote = EsunnySubQuoteType.订阅;
        this.quote.SubQuote(req);
      }
    }



  }
}
