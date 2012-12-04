#include "stdafx.h"
#include "EsunnyCallbackTypeDef.h"

class EsunnyTradeSpi: public IEsunnyTradeSpi
{
public:
	void __cdecl OnOpen();
	void __cdecl OnClose();

	void __cdecl OnLogin(TEsRspField& rsp);
	void __cdecl OnSetPass(TEsRspField& rsp);

	//�ʽ��ѯӦ��
	void __cdecl OnQryMoney(TEsMoneyRspField& rsp);
	//�ʽ�仯Ӧ��
	void __cdecl OnRtnMoney(TEsMoneyRspField& rsp);

	//ί�в�ѯӦ��
	void __cdecl OnQryOrder(TEsOrderInsertRspField* rsp, TEsIsLastType islast);
	//ί�б仯Ӧ��
	void __cdecl OnRtnOrder(TEsOrderInsertRspField& rsp);

	//�ɽ���ѯӦ��
	void __cdecl OnQryMatch(TEsMatchRspField* rsp, TEsIsLastType islast);
	//�ɽ��仯Ӧ��
	void __cdecl OnRtnMatch(TEsMatchRspField& rsp);

	//�ֲֲ�ѯӦ��
	void __cdecl OnQryHold(TEsHoldRspField* rsp, TEsIsLastType islast);
	//�ֱֲ仯Ӧ��
	void __cdecl OnRtnHold(TEsHoldRspField& rsp);

	//�г�״̬��ѯӦ��
	 void __cdecl OnQryExchangeState(TEsExchangeStateRspField* rsp, TEsIsLastType islast);
	//�г�״̬�仯Ӧ��
	 void __cdecl OnRtnExchangeState(TEsExchangeStateRspField& rsp);

	//��Ʒ��ѯӦ��
	 void __cdecl OnQryCommodity(TEsCommodityRspField* rsp, TEsIsLastType islast);
	//��Լ��ѯӦ��
	 void __cdecl OnQryContract(TEsContractRspField* rsp, TEsIsLastType islast);
	//��Ϻ�Լ��ѯӦ��
	 void __cdecl OnQryCmbContract(TEsCmbContractRspField* rsp, TEsIsLastType islast);

	//����Ա�����ͻ���Ϣ��ѯӦ��
	 void __cdecl OnQryClient(TEsClientInfoField* rsp, TEsIsLastType islast);

	//ת�˿ͻ���ѯӦ��
	 void __cdecl OnQryBankClient(TEsBankClientInfoField* rsp, TEsIsLastType islast);
	//ת����ˮ��ѯӦ��
	 void __cdecl OnQryBankCash(TEsBankCashRspField* rsp, TEsIsLastType islast);
	//ת����ˮ�仯Ӧ��
	 void __cdecl OnRtnBankCash(TEsBankCashRspField& rsp);

	//���캯��
	EsunnyTradeSpi(EsunnyTradeSpiCallbackStruct callback);

private:

	//�ص�����ָ��ṹ��
	EsunnyTradeSpiCallbackStruct m_callback;
};


class EsunnyQuoteSpi:IEsunnyQuoteSpi
{
public:
	void __cdecl OnOpen();
	void __cdecl OnClose();

	//������������
	void __cdecl OnQuote(TEsQuoteRspField& rsp);
	//�����������
	void __cdecl OnCmbQuote(TEsCmbQuoteRspField& rsp);

	
	//���캯��
	EsunnyQuoteSpi(EsunnyQuoteSpiCallbackStruct callback);

private:

	//�ص�����ָ��ṹ��
	EsunnyQuoteSpiCallbackStruct m_callback;
};
