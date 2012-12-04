#include "stdafx.h"
#include "EsunnyCallbackTypeDef.h"

class EsunnyTradeSpi: public IEsunnyTradeSpi
{
public:
	void __cdecl OnOpen();
	void __cdecl OnClose();

	void __cdecl OnLogin(TEsRspField& rsp);
	void __cdecl OnSetPass(TEsRspField& rsp);

	//资金查询应答
	void __cdecl OnQryMoney(TEsMoneyRspField& rsp);
	//资金变化应答
	void __cdecl OnRtnMoney(TEsMoneyRspField& rsp);

	//委托查询应答
	void __cdecl OnQryOrder(TEsOrderInsertRspField* rsp, TEsIsLastType islast);
	//委托变化应答
	void __cdecl OnRtnOrder(TEsOrderInsertRspField& rsp);

	//成交查询应答
	void __cdecl OnQryMatch(TEsMatchRspField* rsp, TEsIsLastType islast);
	//成交变化应答
	void __cdecl OnRtnMatch(TEsMatchRspField& rsp);

	//持仓查询应答
	void __cdecl OnQryHold(TEsHoldRspField* rsp, TEsIsLastType islast);
	//持仓变化应答
	void __cdecl OnRtnHold(TEsHoldRspField& rsp);

	//市场状态查询应答
	 void __cdecl OnQryExchangeState(TEsExchangeStateRspField* rsp, TEsIsLastType islast);
	//市场状态变化应答
	 void __cdecl OnRtnExchangeState(TEsExchangeStateRspField& rsp);

	//商品查询应答
	 void __cdecl OnQryCommodity(TEsCommodityRspField* rsp, TEsIsLastType islast);
	//合约查询应答
	 void __cdecl OnQryContract(TEsContractRspField* rsp, TEsIsLastType islast);
	//组合合约查询应答
	 void __cdecl OnQryCmbContract(TEsCmbContractRspField* rsp, TEsIsLastType islast);

	//交易员下属客户信息查询应答
	 void __cdecl OnQryClient(TEsClientInfoField* rsp, TEsIsLastType islast);

	//转账客户查询应答
	 void __cdecl OnQryBankClient(TEsBankClientInfoField* rsp, TEsIsLastType islast);
	//转账流水查询应答
	 void __cdecl OnQryBankCash(TEsBankCashRspField* rsp, TEsIsLastType islast);
	//转账流水变化应答
	 void __cdecl OnRtnBankCash(TEsBankCashRspField& rsp);

	//构造函数
	EsunnyTradeSpi(EsunnyTradeSpiCallbackStruct callback);

private:

	//回调函数指针结构体
	EsunnyTradeSpiCallbackStruct m_callback;
};


class EsunnyQuoteSpi:IEsunnyQuoteSpi
{
public:
	void __cdecl OnOpen();
	void __cdecl OnClose();

	//单腿行情数据
	void __cdecl OnQuote(TEsQuoteRspField& rsp);
	//组合行情数据
	void __cdecl OnCmbQuote(TEsCmbQuoteRspField& rsp);

	
	//构造函数
	EsunnyQuoteSpi(EsunnyQuoteSpiCallbackStruct callback);

private:

	//回调函数指针结构体
	EsunnyQuoteSpiCallbackStruct m_callback;
};
