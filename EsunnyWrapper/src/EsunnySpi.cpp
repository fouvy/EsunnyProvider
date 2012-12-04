
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

//�ʽ��ѯӦ��
void EsunnyTradeSpi::OnQryMoney(TEsMoneyRspField& rsp)
{
	if(this->m_callback.OnQryMoneyCallback)
	{
		(this->m_callback.OnQryMoneyCallback)(rsp);
	}
}
//�ʽ�仯Ӧ��
void EsunnyTradeSpi::OnRtnMoney(TEsMoneyRspField& rsp)
{
	if(this->m_callback.OnRtnMoneyCallback)
	{
		(this->m_callback.OnRtnMoneyCallback)(rsp);
	}
}

//ί�в�ѯӦ��
void EsunnyTradeSpi::OnQryOrder(TEsOrderInsertRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryOrderCallback)
	{
		(this->m_callback.OnQryOrderCallback)(rsp,islast);
	}
}
//ί�б仯Ӧ��
void EsunnyTradeSpi::OnRtnOrder(TEsOrderInsertRspField& rsp)
{
	if(this->m_callback.OnRtnOrderCallback)
	{
		(this->m_callback.OnRtnOrderCallback)(rsp);
	}
}

//�ɽ���ѯӦ��
void EsunnyTradeSpi::OnQryMatch(TEsMatchRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryMatchCallback)
	{
		(this->m_callback.OnQryMatchCallback)(rsp,islast);
	}
}
//�ɽ��仯Ӧ��
void EsunnyTradeSpi::OnRtnMatch(TEsMatchRspField& rsp)
{
	if(this->m_callback.OnRtnMatchCallback)
	{
		(this->m_callback.OnRtnMatchCallback)(rsp);
	}
}

//�ֲֲ�ѯӦ��
void EsunnyTradeSpi::OnQryHold(TEsHoldRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryHoldCallback)
	{
		(this->m_callback.OnQryHoldCallback)(rsp,islast);
	}
}
//�ֱֲ仯Ӧ��
void EsunnyTradeSpi::OnRtnHold(TEsHoldRspField& rsp)
{
	if(this->m_callback.OnRtnHoldCallback)
	{
		(this->m_callback.OnRtnHoldCallback)(rsp);
	}
}

//�г�״̬��ѯӦ��
void EsunnyTradeSpi::OnQryExchangeState(TEsExchangeStateRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryExchangeStateCallback)
	{
		(this->m_callback.OnQryExchangeStateCallback)(rsp,islast);
	}
}
//�г�״̬�仯Ӧ��
void EsunnyTradeSpi::OnRtnExchangeState(TEsExchangeStateRspField& rsp)
{
	if(this->m_callback.OnRtnExchangeStateCallback)
	{
		(this->m_callback.OnRtnExchangeStateCallback)(rsp);
	}
}

//��Ʒ��ѯӦ��
void EsunnyTradeSpi::OnQryCommodity(TEsCommodityRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryCommodityCallback)
	{
		(this->m_callback.OnQryCommodityCallback)(rsp,islast);
	}
}
//��Լ��ѯӦ��
void EsunnyTradeSpi::OnQryContract(TEsContractRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryContractCallback)
	{
		(this->m_callback.OnQryContractCallback)(rsp,islast);
	}
}
//��Ϻ�Լ��ѯӦ��
void EsunnyTradeSpi::OnQryCmbContract(TEsCmbContractRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryCmbContractCallback)
	{
		(this->m_callback.OnQryCmbContractCallback)(rsp,islast);
	}
}

//����Ա�����ͻ���Ϣ��ѯӦ��
void EsunnyTradeSpi::OnQryClient(TEsClientInfoField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryClientCallback)
	{
		(this->m_callback.OnQryClientCallback)(rsp,islast);
	}
}

//ת�˿ͻ���ѯӦ��
void EsunnyTradeSpi::OnQryBankClient(TEsBankClientInfoField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryBankClientCallback)
	{
		(this->m_callback.OnQryBankClientCallback)(rsp,islast);
	}
}
//ת����ˮ��ѯӦ��
void EsunnyTradeSpi::OnQryBankCash(TEsBankCashRspField* rsp, TEsIsLastType islast)
{
	if(this->m_callback.OnQryBankCashCallback)
	{
		(this->m_callback.OnQryBankCashCallback)(rsp,islast);
	}
}
//ת����ˮ�仯Ӧ��
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

