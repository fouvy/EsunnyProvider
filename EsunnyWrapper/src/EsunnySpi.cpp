
#include "..\include\EsunnySpi.h"


EsunnyTradeSpi::EsunnyTradeSpi(EsunnyTradeSpiCallbackStruct callback)
{
	this->m_callback = callback;
}

void EsunnyTradeSpi::OnOpen()
{
	if(this->m_callback.OnOpenCallback)
	{
		(this->m_callback.OnOpenCallback)();
	}
}
void EsunnyTradeSpi::OnClose()
{
	if(this->m_callback.OnCloseCallback)
	{
		(this->m_callback.OnCloseCallback)();
	}
}

void EsunnyTradeSpi::OnLogin(TEsRspField& rsp)
{
	if(this->m_callback.OnLoginCallback)
	{
		(this->m_callback.OnLoginCallback)(rsp);
	}
}
void EsunnyTradeSpi::OnSetPass(TEsRspField& rsp)
{
	if(this->m_callback.OnSetPassCallback)
	{
		(this->m_callback.OnSetPassCallback)(rsp);
	}
}

//资金查询应答
void EsunnyTradeSpi::OnQryMoney(TEsMoneyRspField& rsp)
{
	if(this->m_callback.OnQryMoneyCallback)
	{
		(this->m_callback.OnQryMoneyCallback)(rsp);
	}
}
//资金变化应答
void EsunnyTradeSpi::OnRtnMoney(TEsMoneyRspField& rsp)
{
	if(this->m_callback.OnRtnMoneyCallback)
	{
		(this->m_callback.OnRtnMoneyCallback)(rsp);
	}
}

//委托查询应答
void EsunnyTradeSpi::OnQryOrder(TEsOrderInsertRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryOrderCallback)
	{
		(this->m_callback.OnQryOrderCallback)(rsp,islast);
	}
}
//委托变化应答
void EsunnyTradeSpi::OnRtnOrder(TEsOrderInsertRspField& rsp)
{
	if(this->m_callback.OnRtnOrderCallback)
	{
		(this->m_callback.OnRtnOrderCallback)(rsp);
	}
}

//成交查询应答
void EsunnyTradeSpi::OnQryMatch(TEsMatchRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryMatchCallback)
	{
		(this->m_callback.OnQryMatchCallback)(rsp,islast);
	}
}
//成交变化应答
void EsunnyTradeSpi::OnRtnMatch(TEsMatchRspField& rsp)
{
	if(this->m_callback.OnRtnMatchCallback)
	{
		(this->m_callback.OnRtnMatchCallback)(rsp);
	}
}

//持仓查询应答
void EsunnyTradeSpi::OnQryHold(TEsHoldRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryHoldCallback)
	{
		(this->m_callback.OnQryHoldCallback)(rsp,islast);
	}
}
//持仓变化应答
void EsunnyTradeSpi::OnRtnHold(TEsHoldRspField& rsp)
{
	if(this->m_callback.OnRtnHoldCallback)
	{
		(this->m_callback.OnRtnHoldCallback)(rsp);
	}
}

//市场状态查询应答
void EsunnyTradeSpi::OnQryExchangeState(TEsExchangeStateRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryExchangeStateCallback)
	{
		(this->m_callback.OnQryExchangeStateCallback)(rsp,islast);
	}
}
//市场状态变化应答
void EsunnyTradeSpi::OnRtnExchangeState(TEsExchangeStateRspField& rsp)
{
	if(this->m_callback.OnRtnExchangeStateCallback)
	{
		(this->m_callback.OnRtnExchangeStateCallback)(rsp);
	}
}

//商品查询应答
void EsunnyTradeSpi::OnQryCommodity(TEsCommodityRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryCommodityCallback)
	{
		(this->m_callback.OnQryCommodityCallback)(rsp,islast);
	}
}
//合约查询应答
void EsunnyTradeSpi::OnQryContract(TEsContractRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryContractCallback)
	{
		(this->m_callback.OnQryContractCallback)(rsp,islast);
	}
}
//组合合约查询应答
void EsunnyTradeSpi::OnQryCmbContract(TEsCmbContractRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryCmbContractCallback)
	{
		(this->m_callback.OnQryCmbContractCallback)(rsp,islast);
	}
}

//交易员下属客户信息查询应答
void EsunnyTradeSpi::OnQryClient(TEsClientInfoField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryClientCallback)
	{
		(this->m_callback.OnQryClientCallback)(rsp,islast);
	}
}

//转账客户查询应答
void EsunnyTradeSpi::OnQryBankClient(TEsBankClientInfoField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryBankClientCallback)
	{
		(this->m_callback.OnQryBankClientCallback)(rsp,islast);
	}
}
//转账流水查询应答
void EsunnyTradeSpi::OnQryBankCash(TEsBankCashRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryBankCashCallback)
	{
		(this->m_callback.OnQryBankCashCallback)(rsp,islast);
	}
}
//转账流水变化应答
void EsunnyTradeSpi::OnRtnBankCash(TEsBankCashRspField& rsp)
{
	if(this->m_callback.OnRtnBankCashCallback)
	{
		(this->m_callback.OnRtnBankCashCallback)(rsp);
	}
}



EsunnyQuoteSpi::EsunnyQuoteSpi(EsunnyQuoteSpiCallbackStruct callback)
{
	this->m_callback = callback;
}

void EsunnyQuoteSpi::OnOpen()
{
	if(this->m_callback.OnOpenCallback)
	{
		(this->m_callback.OnOpenCallback)();
	}
}
void EsunnyQuoteSpi::OnClose()
{
	if(this->m_callback.OnCloseCallback)
	{
		(this->m_callback.OnCloseCallback)();
	}
}

void EsunnyQuoteSpi::OnQuote(TEsQuoteRspField& rsp)
{
	if(this->m_callback.OnQuoteCallback)
	{
		(this->m_callback.OnQuoteCallback)(rsp);
	}
}
void EsunnyQuoteSpi::OnCmbQuote(TEsCmbQuoteRspField& rsp)
{
	if(this->m_callback.OnCmbQuoteCallback)
	{
		(this->m_callback.OnCmbQuoteCallback)(rsp);
	}
}

