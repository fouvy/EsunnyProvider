//////////////////////////////////////////////////////////////////////////
/// \file EsunnyApi.h
/// \brief ��ʢ��̬���ṩ����ӿ�
///  
///  1.	�����ĸ��࣬���ĸ���������\n
///  2.	�ĸ����Ϊ���飬��������(IEsunnyTradeApi, IEsunnyTradeSpi)����������(IEsunnyQuoteApi, IEsunnyQuoteSpi)\n
///  3.	Api��β����Ϊ���ú���(��������)��Spi��β����Ϊ�ص�����(��������)\n
///  4.	�������� �ֱ��ṩ����֤����ȡ�汾�����콻��Api����������Api�����\n
///  5.	Api��֤����ʢ��˾���ÿ��Api�Ŀ������ṩApi��֤�룬�Ա���ʶ��ͬ�Ŀ����ߣ��ڻ���˾ͨ����֤���Ӧ��ʶ��������Ƿ�������Ӧ�Ŀ���\n
//////////////////////////////////////////////////////////////////////////

#ifndef _ESUNNY_API_
#define _ESUNNY_API_

#include "EsunnyApiStruct.h"

/// \brief ���ݽ�����ɣ�������ز���������
///
/// ���ڶ�̬��Ŀ�����Ҫ��д�Լ���ע�Ļص�����
/// ���������а���Qry��Ϊ��ѯӦ�𣬰���Rtn��Ϊ��������
class IEsunnyTradeSpi
{
public:
	////////////////////////////////////////
	/// \fn    OnOpen
	/// \brief ������IEsunnyTradeApi�ɹ������뽻�׷���������ʱ�Ļص�����
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnOpen() = 0;

	////////////////////////////////////////
	/// \fn    OnClose
	/// \brief ������IEsunnyTradeApi�Ͽ��뽻�׷���������ʱ�Ļص�����
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnClose() = 0;

	////////////////////////////////////////
	/// \fn    OnLogin
	/// \brief �������յ���¼Ӧ�����ݷ���ʱ�ص�����
	/// \param rsp ��¼�����Ӧ��
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnLogin(TEsRspField& rsp) = 0;

	////////////////////////////////////////
	/// \fn    OnSetPass
	/// \brief �������յ��޸�����Ӧ�����ݷ���ʱ�ص�����
	/// \param rsp �޸����������Ӧ��
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnSetPass(TEsRspField& rsp) = 0;

	////////////////////////////////////////
	/// \fn    OnQryMoney
	/// \brief �յ��ʽ��ѯӦ������ʱ�ص�����
	/// \param rsp �ʽ��ѯӦ��
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnQryMoney(TEsMoneyRspField& rsp) = 0;
	
	////////////////////////////////////////
	/// \fn    OnRtnMoney
	/// \brief �ͻ��ʽ����仯ʱ�ص�����
	/// \param rsp �ͻ��ʽ�仯����
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnRtnMoney(TEsMoneyRspField& rsp) = 0;

    ////////////////////////////////////////
    /// \fn    OnRspOrderInsert
    /// \brief ��������Ӧ��
    /// \param rsp �������������ί�б�źͱ�������ID�ڱ���������
    /// \return void
    ////////////////////////////////////////
	virtual void __cdecl OnRspOrderInsert(TEsOrderInsertRspField& rsp) = 0;

    ////////////////////////////////////////
    /// \fn    OnRspOrderAction
    /// \brief ��������Ӧ��
    /// \param rsp �����������
    /// \return void
    ////////////////////////////////////////
	virtual void __cdecl OnRspOrderAction(TEsOrderActionRspField& rsp) = 0;

	////////////////////////////////////////
	/// \fn    OnQryOrder
	/// \brief ��ѯ����ί��Ӧ��
	/// \param rsp ί�в�ѯ���
	/// \param islast �����Ƿ������ɣ�TRUE-��ɣ�FALSE-δ���
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnQryOrder(TEsOrderInsertRspField* rsp, TEsIsLastType islast) = 0;
	
	////////////////////////////////////////
	/// \fn    OnRtnOrder
	/// \brief ί��״̬�����仯ʱ�ص�����
	/// \param rsp �����仯��ί����Ϣ
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnRtnOrder(TEsOrderInsertRspField& rsp) = 0;
	
	////////////////////////////////////////
	/// \fn    OnQryMatch
	/// \brief �ɽ���ѯӦ�����ݷ���ʱ�ص�����
	/// \param rsp �ɽ���ѯ���
	/// \param islast �����Ƿ������ɣ�TRUE-��ɣ�FALSE-δ���
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnQryMatch(TEsMatchRspField* rsp, TEsIsLastType islast) = 0;
	
	////////////////////////////////////////
	/// \fn    OnRtnMatch
	/// \brief �ɽ������仯ʱ�ص�����
	/// \param rsp �����仯�ĳɽ�����
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnRtnMatch(TEsMatchRspField& rsp) = 0;

	////////////////////////////////////////
	/// \fn    OnQryHold
	/// \brief �ֲֲ�ѯӦ�����ݷ���ʱ�ص�����
	/// \param rsp �ֲֲ�ѯ���
	/// \param islast �����Ƿ������ɣ�TRUE-��ɣ�FALSE-δ���
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnQryHold(TEsHoldRspField* rsp, TEsIsLastType islast) = 0;
	
	////////////////////////////////////////
	/// \fn    OnRtnHold
	/// \brief �ֱֲ仯ʱ�ص�����
	/// \param rsp �����仯�ĳֲ�����
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnRtnHold(TEsHoldRspField& rsp) = 0;

	////////////////////////////////////////
	/// \fn    OnQryExchangeState
	/// \brief �г�״̬��ѯӦ�����ݷ���ʱ�ص�����
	/// \param rsp �г�״̬��ѯ���
	/// \param islast �����Ƿ������ɣ�TRUE-��ɣ�FALSE-δ���
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnQryExchangeState(TEsExchangeStateRspField* rsp, TEsIsLastType islast) = 0;
	
	////////////////////////////////////////
	/// \fn    OnRtnExchangeState
	/// \brief �г�״̬�仯ʱ�ص�����
	/// \param rsp �г�״̬�仯��Ϣ
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnRtnExchangeState(TEsExchangeStateRspField& rsp) = 0;

	////////////////////////////////////////
	/// \fn    OnQryCommodity
	/// \brief ��Ʒ��ѯӦ�����ݷ���ʱ�ص�����
	/// \param rsp ��Ʒ��ѯ���
	/// \param islast �����Ƿ������ɣ�TRUE-��ɣ�FALSE-δ���
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnQryCommodity(TEsCommodityRspField* rsp, TEsIsLastType islast) = 0;

	////////////////////////////////////////
	/// \fn    OnQryContract
	/// \brief ��Լ��ѯӦ�����ݷ���ʱ�ص�����
	/// \param rsp ��Լ��ѯ���
	/// \param islast �����Ƿ������ɣ�TRUE-��ɣ�FALSE-δ���
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnQryContract(TEsContractRspField* rsp, TEsIsLastType islast) = 0;
	
	////////////////////////////////////////
	/// \fn    OnQryCmbContract
	/// \brief ��Ϻ�Լ��ѯӦ�����ݷ���ʱ�ص�����
	/// \param rsp ��Ϻ�Լ��ѯ���
	/// \param islast �����Ƿ������ɣ�TRUE-��ɣ�FALSE-δ���
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnQryCmbContract(TEsCmbContractRspField* rsp, TEsIsLastType islast) = 0;

	////////////////////////////////////////
	/// \fn    OnQryClient
	/// \brief ����Ա�����ͻ���Ϣ��ѯӦ�����ݷ���ʱ�ص�����
	/// \param rsp ����Ա�����ͻ���Ϣ��ѯ���
	/// \param islast �����Ƿ������ɣ�TRUE-��ɣ�FALSE-δ���
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnQryClient(TEsClientInfoField* rsp, TEsIsLastType islast) = 0;

	////////////////////////////////////////
	/// \fn    OnQryBankClient
	/// \brief ת�˿ͻ���ѯӦ�����ݷ���ʱ�ص�����
	/// \param rsp ת�˿ͻ���ѯ���
	/// \param islast �����Ƿ������ɣ�TRUE-��ɣ�FALSE-δ���
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnQryBankClient(TEsBankClientInfoField* rsp, TEsIsLastType islast) = 0;
	
	////////////////////////////////////////
	/// \fn    OnQryBankCash
	/// \brief ת����ˮ��ѯӦ�����ݷ���ʱ�ص�����
	/// \param rsp ת����ˮ��ѯ���
	/// \param islast �����Ƿ������ɣ�TRUE-��ɣ�FALSE-δ���
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnQryBankCash(TEsBankCashRspField* rsp, TEsIsLastType islast) = 0;
	
	////////////////////////////////////////
	/// \fn    OnRtnBankCash
	/// \brief ת����ˮ�仯ʱ�ص�����
	/// \param rsp �����仯��ת����ˮ����
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnRtnBankCash(TEsBankCashRspField& rsp) = 0;
};

/// \brief ���׵Ľӿ���
///
/// ���ڶ�̬��Ŀ�����������ʵ�ֽӿڣ���ȡapi��ʵ����ͨ����ʵ�����ýӿڼ���
class IEsunnyTradeApi
{
public:
	////////////////////////////////////////
	/// \brief ���ûص����ݽӿ�
	/// \param spi ������IEsunnyTradeSpi��ҵ������
	/// \return   void
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual void __cdecl SetSpi(IEsunnyTradeSpi* spi) = 0;
	
	////////////////////////////////////////
	/// \fn    Free
	/// \brief �ͷŵ�ǰapi�Ự
	/// \return   void
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual void __cdecl Free() = 0;

	////////////////////////////////////////
	/// \brief ���ӽ��׷�����
	/// \param addr ���׷��������ӵ�ַ��Ϣ
	/// \return   bool �Ƿ�ɹ���������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual bool __cdecl Open(TEsAddressField& addr) = 0;
	
	////////////////////////////////////////
	/// \fn    Close
	/// \brief �رս��׷���
	/// \return   void
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual void __cdecl Close() = 0;
	
	////////////////////////////////////////
	/// \fn    IsOpen
	/// \brief ��ȡ��ǰ���״���ʵ���Ƿ�����
	/// \return   bool TRUE-�ɹ�����, FALSE-δ����
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual bool __cdecl IsOpen() = 0;

	////////////////////////////////////////
	/// \fn    Login
	/// \brief �����¼����
	/// \param req ��¼��Ϣ
	/// \return   int �Ƿ�ɹ����͵�¼�����Ƿ��¼�ɹ���Ҫ�ڵ�¼��Ӧ�ص�������ȡ
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl Login(TEsLoginReqField& req) = 0;
	
	////////////////////////////////////////
	/// \fn    GetTradingDay
	/// \brief ��ȡ���ڣ���¼�ɹ��� ���ɻ�ȡ��������
	/// \param day ��������
	/// \return   void
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual void __cdecl GetTradingDay(TEsDateTimeType day) = 0;
	
	////////////////////////////////////////
	/// \fn    SetPass
	/// \brief �޸ĸ�������
	/// \param req �����޸�������Ϣ
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl SetPass(TEsSetPassReqField& req) = 0;

	////////////////////////////////////////
	/// \fn    QryClients
	/// \brief ��ѯ����Ա�����ͻ�
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl QryClients() = 0;
	
	////////////////////////////////////////
	/// \fn    QryBankClients
	/// \brief ��ѯת�˿ͻ�
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl QryBankClients() = 0;
	
	////////////////////////////////////////
	/// \fn    QryBankCash
	/// \brief ��ѯת����ˮ
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl QryBankCash() = 0;
	
	////////////////////////////////////////
	/// \fn    BankTrade
	/// \brief ת�˲���
	/// \param req
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl BankTrade(TEsBankCashReqField& req) = 0;

	////////////////////////////////////////
	/// \fn    QryMoney
	/// \brief ��ѯ�ͻ��ʽ�
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl QryMoney() = 0;
	
	////////////////////////////////////////
	/// \fn    QryOrder
	/// \brief ��ѯ�ͻ�ί�У���ѯ�������ݣ�������0�����ߴӷ��������л�ȡ��ǰ�����б����һ������
	/// \param streamid
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl QryOrder(TEsStreamIDType streamid) = 0;
	
	////////////////////////////////////////
	/// \fn    QryMatch
	/// \brief ��ѯ�ͻ��ɽ�����ѯ�������ݣ�������0�����ߴӷ��������л�ȡ��ǰ�����б����һ������
	/// \param streamid
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl QryMatch(TEsStreamIDType streamid) = 0;
	
	////////////////////////////////////////
	/// \fn    QryHold
	/// \brief ��ѯ���ȳֲ�
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl QryHold() = 0;

    ////////////////////////////////////////
    /// \fn    QryCmbHold
    /// \brief ��ѯ��ϳֲ�
	/// \return int ������룬0Ϊ�ɹ�
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
    ////////////////////////////////////////
	virtual int __cdecl QryCmbHold() = 0;

	////////////////////////////////////////
	/// \fn    QryExchangeState
	/// \brief ��ѯ������״̬  ����������ʱ��
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl QryExchangeState() = 0;
	
	////////////////////////////////////////
	/// \fn    QryCommodity
	/// \brief ��ѯ������Ʒ
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl QryCommodity() = 0;
	
	////////////////////////////////////////
	/// \fn    QryContract
	/// \brief ��ѯ���Ⱥ�Լ
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl QryContract() = 0;
	
	////////////////////////////////////////
	/// \fn    QryCmbContract
	/// \brief ��ѯ��Ϻ�Լ
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl QryCmbContract() = 0;

	////////////////////////////////////////
	/// \fn    OrderInsert
	/// \brief ��������
	/// \param req ������������
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl OrderInsert(TEsOrderInsertReqField& req) = 0;
	
	////////////////////////////////////////
	/// \fn    OrderAction
	/// \brief ����������Ŀǰֻ֧�ֳ�������
	/// \param req ������������
	/// \return   int �����ͳɹ�Ϊ0������Ϊ������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual int __cdecl OrderAction(TEsOrderActionReqField& req) = 0;
};

/// \brief ���ݽ�����ɣ�������ز���������
///
/// ���ڶ�̬��Ŀ�����Ҫ��д�Լ���ע�Ļص�����
/// ���������а���Qry��Ϊ��ѯӦ�𣬰���Rtn��Ϊ��������
class IEsunnyQuoteSpi
{
public:
	////////////////////////////////////////
	/// \fn    OnOpen
	/// \brief ����ӿ�API�뽻�׷������ɹ�����ʱ�Ļص�����
	/// \return   void 
	////////////////////////////////////////
	virtual void __cdecl OnOpen() = 0;

	////////////////////////////////////////
	/// \fn    OnClose
	/// \brief ����ӿ�API�뽻�׷������Ͽ�����ʱ�Ļص�����
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnClose() = 0;

	////////////////////////////////////////
	/// \fn    OnQuote
	/// \brief ���������ѯ�����ݷ���ʱ�ص�����
	/// \param rsp ������������
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnQuote(TEsQuoteRspField& rsp) = 0;
	
	////////////////////////////////////////
	/// \fn    OnCmbQuote
	/// \brief ����������ݲ�ѯ�����ݷ���ʱ�ص�����
	/// \param rsp �����������
	/// \return   void
	////////////////////////////////////////
	virtual void __cdecl OnCmbQuote(TEsCmbQuoteRspField& rsp) = 0;
};

/// \brief �����ѯ�Ľӿ���
///
/// ���ڶ�̬��Ŀ�����������ʵ�ֽӿڣ���ȡapi��ʵ����ͨ����ʵ�����ýӿڼ���
class IEsunnyQuoteApi
{
public:
    ////////////////////////////////////////
    /// \fn    SetSpi
    /// \brief ���ô����������ݵ�ʵ��
    /// \param spi ������IEsunnyQuoteSpi���ʵ��
    /// \return   void
    /// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
    ////////////////////////////////////////
	virtual void __cdecl SetSpi(IEsunnyQuoteSpi* spi) = 0;

	////////////////////////////////////////
	/// \fn    Free
	/// \brief �ͷŵ�ǰAPI�Ự
	/// \return   void
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual void __cdecl Free() = 0;

	////////////////////////////////////////
	/// \fn    Open
	/// \brief �����뽻�׷����������ӣ�����api��¼�ɹ�����ܽ�����������
	/// \param addr ���׷������ĵ�ַ��Ϣ
	/// \return   bool �Ƿ�ɹ���������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual bool __cdecl Open(TEsAddressField& addr) = 0;

	////////////////////////////////////////
	/// \fn    Close
	/// \brief �ر��뽻�׷�����������
	/// \return   void
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual void __cdecl Close() = 0;
	
	////////////////////////////////////////
	/// \fn    IsOpen
	/// \brief ��ȡ��ǰ���鴦��ʵ���Ƿ��Ѿ��ɹ����ӽ��׷�����
	/// \return   bool
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual bool __cdecl IsOpen() = 0;

	////////////////////////////////////////
	/// \fn    SubQuote
	/// \brief ���鶩�Ļ��˶�����Ϊ�˶�����ʱ���˶������Ѷ�����������
	/// \param req ���Ļ��˶��������������
	/// \return   bool �Ƿ�ɹ����Ļ��˶�
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual bool __cdecl SubQuote(TEsQuoteReqField& req) = 0;

	////////////////////////////////////////
	/// \fn    GetQuote
	/// \brief ��ȡ��������
	/// \param data ������������
	/// \return   bool �Ƿ�ɹ���ȡ��������
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual bool __cdecl GetQuote(TEsQuoteRspField& data) = 0;

	////////////////////////////////////////
	/// \fn    GetCmbQuote
	/// \brief ��ȡ��Ϻ�Լ����
	/// \param data ��Ϻ�Լ��������
	/// \return   bool
	/// \note ���ڶ�̬��Ŀ���������д��������ͨ�������ָ����ñ��ӿڼ���
	////////////////////////////////////////
	virtual bool __cdecl GetCmbQuote(TEsCmbQuoteRspField& data) = 0;
};

extern "C"
{
	////////////////////////////////////////
	/// \brief ��������֤���������ÿ��������һ����֤��
	/// \param cert ��������֤��Ϣ
	/// \param path ��־·��,Ĭ��Ϊ��ǰ����Ŀ¼��
	/// \param logLevel ��¼��־���� 0-��¼������API������־ 1-��¼����API������־��Ĭ��Ϊ1
	/// \return   int �������
	////////////////////////////////////////
	int __cdecl CertEsunnyApi(TEsCertInfoType cert, TEsLogPathType path = NULL, TEsLogLevel logLevel = 1);

	////////////////////////////////////////
	/// \brief ��ȡ��̬��汾
	/// \param version ��̬��汾��
	/// \return   void
	////////////////////////////////////////
	void __cdecl GetEsunnyApiVersion(TEsVersionType version);

	////////////////////////////////////////
	/// \fn    CreateEsunnyTradeApi
	/// \brief �������״���APIʵ���������֤ʧ�ܷ���NULL
	/// \return   IEsunnyTradeApi* ���״���APIʵ����ָ��
	////////////////////////////////////////
	IEsunnyTradeApi* __cdecl CreateEsunnyTradeApi();

	////////////////////////////////////////
	/// \fn    CreateEsunnyQuoteApi
	/// \brief �������鴦��APIʵ���������֤ʧ�ܷ���NULL
	/// \return   IEsunnyQuoteApi* ���鴦��APIʵ����ָ��
	////////////////////////////////////////
	IEsunnyQuoteApi* __cdecl CreateEsunnyQuoteApi();
}


#endif