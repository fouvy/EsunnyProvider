#include "stdafx.h"


typedef void (WINAPI *OpenCallbackType)();
typedef void (WINAPI *CloseCallbackType)();

typedef void (WINAPI *LoginCallbackType)(TEsRspField rsp);
typedef void (WINAPI *SetPassCallbackType)(TEsRspField rsp);

//资金查询应答
typedef void (WINAPI *QryMoneyCallbackType)(TEsMoneyRspField rsp);
//资金变化应答
typedef void (WINAPI *RtnMoneyCallbackType)(TEsMoneyRspField rsp);

//委托查询应答
typedef void (WINAPI *QryOrderCallbackType)(TEsOrderInsertRspField* rsp, TEsIsLastType islast);
//委托变化应答
typedef void (WINAPI *RtnOrderCallbackType)(TEsOrderInsertRspField rsp);

//成交查询应答
typedef void (WINAPI *QryMatchCallbackType)(TEsMatchRspField* rsp, TEsIsLastType islast);
//成交变化应答
typedef void (WINAPI *RtnMatchCallbackType)(TEsMatchRspField rsp);

//持仓查询应答
typedef void (WINAPI *QryHoldCallbackType)(TEsHoldRspField* rsp, TEsIsLastType islast);
//持仓变化应答
typedef void (WINAPI *RtnHoldCallbackType)(TEsHoldRspField rsp);

//市场状态查询应答
typedef void (WINAPI *QryExchangeStateCallbackType)(TEsExchangeStateRspField* rsp, TEsIsLastType islast);
//市场状态变化应答
typedef void (WINAPI *RtnExchangeStateCallbackType)(TEsExchangeStateRspField rsp);

//商品查询应答
typedef void (WINAPI *QryCommodityCallbackType)(TEsCommodityRspField* rsp, TEsIsLastType islast);
//合约查询应答
typedef void (WINAPI *QryContractCallbackType)(TEsContractRspField* rsp, TEsIsLastType islast);
//组合合约查询应答
typedef void (WINAPI *QryCmbContractCallbackType)(TEsCmbContractRspField* rsp, TEsIsLastType islast);

//交易员下属客户信息查询应答
typedef void (WINAPI *QryClientCallbackType)(TEsClientInfoField* rsp, TEsIsLastType islast);

//转账客户查询应答
typedef void (WINAPI *QryBankClientCallbackType)(TEsBankClientInfoField* rsp, TEsIsLastType islast);
//转账流水查询应答
typedef void (WINAPI *QryBankCashCallbackType)(TEsBankCashRspField* rsp, TEsIsLastType islast);
//转账流水变化应答
typedef void (WINAPI *RtnBankCashCallbackType)(TEsBankCashRspField rsp);



//交易回调函数结构体
struct EsunnyTradeSpiCallbackStruct
{
	OpenCallbackType OnOpenCallback;
	CloseCallbackType OnCloseCallback;
 
	LoginCallbackType OnLoginCallback;
	SetPassCallbackType OnSetPassCallback;
 
	//资金查询应答 
	QryMoneyCallbackType OnQryMoneyCallback;
	//资金变化应答 
	RtnMoneyCallbackType OnRtnMoneyCallback;
 
	//委托查询应答 
	QryOrderCallbackType OnQryOrderCallback;
	//委托变化应答 
	RtnOrderCallbackType OnRtnOrderCallback;
 
	//成交查询应答 
	QryMatchCallbackType OnQryMatchCallback;
	//成交变化应答 
	RtnMatchCallbackType OnRtnMatchCallback;
 
	//持仓查询应答 
	QryHoldCallbackType OnQryHoldCallback;
	//持仓变化应答 
	RtnHoldCallbackType OnRtnHoldCallback;
 
	//市场状态查询应答 
	QryExchangeStateCallbackType OnQryExchangeStateCallback;
	//市场状态变化应答 
	RtnExchangeStateCallbackType OnRtnExchangeStateCallback;
 
	//商品查询应答 
	QryCommodityCallbackType OnQryCommodityCallback;
	//合约查询应答 
	QryContractCallbackType OnQryContractCallback;
	//组合合约查询应答 
	QryCmbContractCallbackType OnQryCmbContractCallback;

	//交易员下属客户信息查询应答 
	QryClientCallbackType OnQryClientCallback;

	//转账客户查询应答 
	QryBankClientCallbackType OnQryBankClientCallback;
	//转账流水查询应答 
	QryBankCashCallbackType OnQryBankCashCallback;
	//转账流水变化应答 
	RtnBankCashCallbackType OnRtnBankCashCallback;

};

	//单腿行情数据
typedef void (WINAPI *QuoteCallbackType)(TEsQuoteRspField rsp);
	//组合行情数据
typedef void (WINAPI *CmbQuoteCallbackType)(TEsCmbQuoteRspField rsp);


//行情回调函数结构体
struct EsunnyQuoteSpiCallbackStruct
{
	OpenCallbackType OnOpenCallback;
	CloseCallbackType OnCloseCallback;
	QuoteCallbackType OnQuoteCallback;
	CmbQuoteCallbackType OnCmbQuoteCallback;
};