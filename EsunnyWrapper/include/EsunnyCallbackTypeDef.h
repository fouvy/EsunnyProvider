#include "stdafx.h"


typedef void (WINAPI *OpenCallbackType)();
typedef void (WINAPI *CloseCallbackType)();

typedef void (WINAPI *LoginCallbackType)(TEsRspField rsp);
typedef void (WINAPI *SetPassCallbackType)(TEsRspField rsp);

//�ʽ��ѯӦ��
typedef void (WINAPI *QryMoneyCallbackType)(TEsMoneyRspField rsp);
//�ʽ�仯Ӧ��
typedef void (WINAPI *RtnMoneyCallbackType)(TEsMoneyRspField rsp);

//ί�в�ѯӦ��
typedef void (WINAPI *QryOrderCallbackType)(TEsOrderInsertRspField* rsp, TEsIsLastType islast);
//ί�б仯Ӧ��
typedef void (WINAPI *RtnOrderCallbackType)(TEsOrderInsertRspField rsp);

//�ɽ���ѯӦ��
typedef void (WINAPI *QryMatchCallbackType)(TEsMatchRspField* rsp, TEsIsLastType islast);
//�ɽ��仯Ӧ��
typedef void (WINAPI *RtnMatchCallbackType)(TEsMatchRspField rsp);

//�ֲֲ�ѯӦ��
typedef void (WINAPI *QryHoldCallbackType)(TEsHoldRspField* rsp, TEsIsLastType islast);
//�ֱֲ仯Ӧ��
typedef void (WINAPI *RtnHoldCallbackType)(TEsHoldRspField rsp);

//�г�״̬��ѯӦ��
typedef void (WINAPI *QryExchangeStateCallbackType)(TEsExchangeStateRspField* rsp, TEsIsLastType islast);
//�г�״̬�仯Ӧ��
typedef void (WINAPI *RtnExchangeStateCallbackType)(TEsExchangeStateRspField rsp);

//��Ʒ��ѯӦ��
typedef void (WINAPI *QryCommodityCallbackType)(TEsCommodityRspField* rsp, TEsIsLastType islast);
//��Լ��ѯӦ��
typedef void (WINAPI *QryContractCallbackType)(TEsContractRspField* rsp, TEsIsLastType islast);
//��Ϻ�Լ��ѯӦ��
typedef void (WINAPI *QryCmbContractCallbackType)(TEsCmbContractRspField* rsp, TEsIsLastType islast);

//����Ա�����ͻ���Ϣ��ѯӦ��
typedef void (WINAPI *QryClientCallbackType)(TEsClientInfoField* rsp, TEsIsLastType islast);

//ת�˿ͻ���ѯӦ��
typedef void (WINAPI *QryBankClientCallbackType)(TEsBankClientInfoField* rsp, TEsIsLastType islast);
//ת����ˮ��ѯӦ��
typedef void (WINAPI *QryBankCashCallbackType)(TEsBankCashRspField* rsp, TEsIsLastType islast);
//ת����ˮ�仯Ӧ��
typedef void (WINAPI *RtnBankCashCallbackType)(TEsBankCashRspField rsp);



//���׻ص������ṹ��
struct EsunnyTradeSpiCallbackStruct
{
	OpenCallbackType OnOpenCallback;
	CloseCallbackType OnCloseCallback;
 
	LoginCallbackType OnLoginCallback;
	SetPassCallbackType OnSetPassCallback;
 
	//�ʽ��ѯӦ�� 
	QryMoneyCallbackType OnQryMoneyCallback;
	//�ʽ�仯Ӧ�� 
	RtnMoneyCallbackType OnRtnMoneyCallback;
 
	//ί�в�ѯӦ�� 
	QryOrderCallbackType OnQryOrderCallback;
	//ί�б仯Ӧ�� 
	RtnOrderCallbackType OnRtnOrderCallback;
 
	//�ɽ���ѯӦ�� 
	QryMatchCallbackType OnQryMatchCallback;
	//�ɽ��仯Ӧ�� 
	RtnMatchCallbackType OnRtnMatchCallback;
 
	//�ֲֲ�ѯӦ�� 
	QryHoldCallbackType OnQryHoldCallback;
	//�ֱֲ仯Ӧ�� 
	RtnHoldCallbackType OnRtnHoldCallback;
 
	//�г�״̬��ѯӦ�� 
	QryExchangeStateCallbackType OnQryExchangeStateCallback;
	//�г�״̬�仯Ӧ�� 
	RtnExchangeStateCallbackType OnRtnExchangeStateCallback;
 
	//��Ʒ��ѯӦ�� 
	QryCommodityCallbackType OnQryCommodityCallback;
	//��Լ��ѯӦ�� 
	QryContractCallbackType OnQryContractCallback;
	//��Ϻ�Լ��ѯӦ�� 
	QryCmbContractCallbackType OnQryCmbContractCallback;

	//����Ա�����ͻ���Ϣ��ѯӦ�� 
	QryClientCallbackType OnQryClientCallback;

	//ת�˿ͻ���ѯӦ�� 
	QryBankClientCallbackType OnQryBankClientCallback;
	//ת����ˮ��ѯӦ�� 
	QryBankCashCallbackType OnQryBankCashCallback;
	//ת����ˮ�仯Ӧ�� 
	RtnBankCashCallbackType OnRtnBankCashCallback;

};

	//������������
typedef void (WINAPI *QuoteCallbackType)(TEsQuoteRspField rsp);
	//�����������
typedef void (WINAPI *CmbQuoteCallbackType)(TEsCmbQuoteRspField rsp);


//����ص������ṹ��
struct EsunnyQuoteSpiCallbackStruct
{
	OpenCallbackType OnOpenCallback;
	CloseCallbackType OnCloseCallback;
	QuoteCallbackType OnQuoteCallback;
	CmbQuoteCallbackType OnCmbQuoteCallback;
};