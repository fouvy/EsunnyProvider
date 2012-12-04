//////////////////////////////////////////////////////////////////////////
/// \file EsunnyApiStruct.h
/// \brief ��ʢ��̬��ҵ�������õ���������
/// 
///  ҵ���������õ������������ɻ�������������϶��ɵģ��뽻�׷�����֮��
///  ��ͨ�ű�����Ҫ�����Щ��������ߴ���Щ��������ȡ����Ϣ
//////////////////////////////////////////////////////////////////////////
#ifndef _ESUNNY_API_STRUCT_
#define _ESUNNY_API_STRUCT_

#include "EsunnyApiType.h"

/// \brief ���ӵ����׷�����IP���˿���Ϣ��
struct TEsAddressField
{
    TEsIpType					Ip;     ///< ���׷�����IP��ַ
    TEsPortType					Port;   ///< ���׷������˿ں�
};

///����Ӧ����
struct TEsRspField
{
    TEsErrorCodeType			ErrorCode; ///< �����룬Ϊ0��ʾ�ɹ�
    TEsErrorInfoType			ErrorInfo; ///< ������ϸ����
};

///��¼������
struct TEsLoginReqField
{
    TEsLoginTypeType			LoginType; ///< 'C'-���ͻ�,'T'-����Ա
    TEsLoginNoType				LoginNo;   ///< ��¼��
    TEsPasswordType				Password;  ///< ��¼����
};

///�޸�����������
struct TEsSetPassReqField
{
    TEsPasswordType				OldPassword; ///< ������
    TEsPasswordType				NewPassword; ///< ������
};

///����Ա�����ͻ���Ϣ��ѯӦ����
struct TEsClientInfoField
{
    TEsClientNoType				ClientNo;   ///< �ͻ���
    TEsClientNameType			ClientName; ///< �ͻ�����
};

///�ͻ������˺���Ϣ��
struct TEsBankClientInfoField
{
    TEsBankGroupNoType			GroupNo;        ///< ת�˷����
    TEsClientNoType				ClientNo;       ///< �ͻ���
    TEsBankType					BankId;         ///< ���б�ʶ
    TEsBankClientNoType			BankClientNo;   ///< �����ʺ�
    TEsPersonIdType				PersonId;       ///< ���֤��
    TEsPersonNameType			PersonName;     ///< �ͻ�����
    TEsBankClientStateType		State;          ///< ת��״̬
};

///ת�˲���������
struct TEsBankCashReqField
{
    TEsBankClientInfoField		BankClient;             ///< �ͻ������˺���Ϣ
    TEsPasswordType				BankPassword;			///< ��������
    TEsPasswordType				FuturePassword;			///< �ڻ�����
    TEsBankTradeTypeType		TradeType;				///< ת������
    TEsBankMoneyType			Money;					///< ת�˽��
};

///ת�˲�����Ӧ��
struct TEsBankCashRspField
{
    TEsClientNoType				ClientNo;				///< �ͻ���
    TEsBankType					BankId;					///< ���б�ʶ
    TEsBankClientNoType			BankClientNo;			///< �����ʺ�
    TEsBankPackFlagType			PackFlag;				///< ��������
    TEsBankTrTradeTypeType		TrTradeType;			///< ��������
    TEsBankSerNo				BankSerNo;				///< ������ˮ��
    TEsBankSerNo				FutureSerNo;			///< �ڻ���ˮ��
    TEsBankMoneyType			Money;					///< ת�˽��
    TEsClientNoType				OperNo;					///< ת�˲�����
    TEsDateTimeType				DateTime;				///< ����ʱ��
    TEsBankRetCode				RetCode;				///< �����룬��ErrorCode.dat�ļ�������
};

///��ѯ�ʽ�Ӧ����
struct TEsMoneyRspField
{
    TEsClientNoType				ClientNo;			///< �ͻ���
    TEsMoneyValueType			YAvailable;			///< ������ʽ�
    TEsMoneyValueType			YMoney;				///< �������ʽ�
    TEsMoneyValueType			YBalance;			///< ���ʽ�Ȩ��
    TEsMoneyValueType			CashOut;			///< ����
    TEsMoneyValueType			CashIn;				///< ���
    TEsMoneyValueType			Fee;				///< ������
    TEsMoneyValueType			Deposit;			///< ��֤��
    TEsMoneyValueType			Frozen;				///< ���ᱣ֤��
    TEsMoneyValueType			CoverProfit;		///< ƽ��ӯ��(���)
    TEsMoneyValueType			FloatProfit;		///< �ֲ�ӯ��(���)
    TEsMoneyValueType			DayCoverProfit;		///< ƽ��ӯ��(����)
    TEsMoneyValueType			DayFloatProfit;		///< �ֲ�ӯ��(����)
    TEsMoneyValueType			TAvailable;			///< ������ʽ�
    TEsMoneyValueType			TMoney;				///< �������ʽ�
    TEsMoneyValueType			TBalance;			///< ���ʽ�Ȩ��
};

///�ͻ�����������
struct TEsOrderInsertReqField
{
    TEsClientNoType				ClientNo;			///< �ͻ���
    TEsRequestIndexType			RequestID;          ///< ������, ���TEsRequestIndexType����
    TEsOrderTypeType			OrderType;          ///< ί������
    TEsExchangeType				Exchange;           ///< ������
    TEsCmbTypeType				CmbType;            ///< �������
    TEsContractType				Contract1;          ///< ��Լ1����
    TEsContractType				Contract2;          ///< ��Լ2����
    TEsDirectType				Direct;             ///< ������ʶ
    TEsOffsetType				Offset;             ///< ��ƽ�ֱ�ʶ
    TEsHedgeType				Hedge;              ///< Ͷ����ʶ
    TEsTradePriceType			OrderPrice;         ///< ���׼۸�
    TEsTradeVolType				OrderVol;           ///< ��������
};

///�ͻ�����Ӧ����
struct TEsOrderInsertRspField
{
    TEsClientNoType				ClientNo;   ///< �ͻ���
    TEsOrderInsertReqField		ReqData;    ///< �ͻ�����������
    TEsRspField					RspHead;    ///< ������
    TEsOrderStateType			OrderState; ///< ί��״̬�����TEsOrderStateType����
    TEsOrderNoType				OrderNo;    ///< ί�к�
    TEsLocalNoType				LocalNo;    ///< ���غ�
    TEsSystemNoType				SystemNo;   ///< ϵͳ��
    TEsMemberNoType				MemberNo;   ///< ��Ա��
    TEsPosNoType				PosNo;      ///< ϯλ��
    TEsTradePriceType			MatchPrice; ///< ��ʱ����
    TEsTradeVolType				MatchVol;   ///< �ɽ�����
    TEsDateTimeType				InsertTime; ///< ����¼��ʱ��
    TEsDateTimeType				DeleteTime; ///< ����ɾ��ʱ��
    TEsClientNoType				InsertNo;   ///< �µ��ͻ���
    TEsClientNoType				DeleteNo;   ///< �����ͻ���
    TEsStreamIDType				StreamID;   ///< ��������
    TEsErrorInfoType			OrderEcho;  ///< �ϼ�ϵͳ������Ϣ��ʾ
};

///�ͻ�����������Ŀǰֻ֧�ֳ�������
struct TEsOrderActionReqField
{
    TEsClientNoType				ClientNo;   ///< �ͻ���
    TEsExchangeType				Exchange;   ///< ������
    TEsContractType				Contract;   ///< ��Լ����
    TEsOrderNoType				OrderNo;    ///< ί�к�
    TEsSystemNoType				SystemNo;   ///< ϵͳ��
};

///�ͻ���������Ӧ����
struct TEsOrderActionRspField
{
    TEsClientNoType				ClientNo;   ///< �ͻ���
    TEsOrderActionReqField		ReqData;	///< ������������
    TEsRspField					RspHead;	///< ������
    TEsOrderStateType			OrderState;	///< ί��״̬
    TEsDirectType				Direct;		///< ��������
    TEsOffsetType				Offset;		///< ��ƽ�ֱ�־
    TEsHedgeType				Hedge;		///< Ͷ����ֵ��־
    TEsLocalNoType				LocalNo;	///< ί�еķ��������ر��
    TEsTradePriceType           OrderPrice;	///< ί�м۸�
    TEsDateTimeType				InsertTime;	///< ¼��ʱ��
    TEsDateTimeType				DeleteTime;	///< ɾ��ʱ��
    TEsClientNoType				InsertNo;	///< ¼���˱��
    TEsClientNoType				DeleteNo;	///< ɾ���˱��
    TEsStreamIDType				StreamID;	///< �������������
};

///�ɽ���ѯӦ����
struct TEsMatchRspField
{
    TEsClientNoType				ClientNo;   ///< �ͻ���
    TEsLocalNoType				LocalNo;    ///< ���غ�
    TEsSystemNoType				SystemNo;   ///< ϵͳ��
    TEsMatchNoType				MatchNo;    ///< �ɽ���
    TEsExchangeType				Exchange;   ///< ������
    TEsContractType				Contract;   ///< ��Լ����
    TEsDirectType				Direct;     ///< ��������
    TEsOffsetType				Offset;     ///< ��ƽ�ֱ�ʶ
    TEsHedgeType				Hedge;      ///< Ͷ����ʶ
    TEsTradePriceType			MatchPrice; ///< �ɽ��۸�
    TEsTradeVolType				MatchVol;   ///< �ɽ�����
    TEsTimeType					MatchTime;  ///< �ɽ�ʱ��
    TEsMoneyValueType			Fee;        ///< ������
    TEsStreamIDType				StreamID;   ///< ��������
};

/// ��ѯ�ͻ��ֲ�Ӧ����
struct TEsHoldRspField
{
    TEsClientNoType				ClientNo;   ///< �ͻ���
    TEsMatchNoType				MatchNo;    ///< �ɽ���
    TEsMatchNoType				CmbMatchNo; ///< ��Ϻ�Լ�ɽ���
    TEsExchangeType				Exchange;   ///< ������
    TEsCmbTypeType				CmbType;    ///< �������
    TEsContractType				Contract1;  ///< ��Լ1����
    TEsContractType				Contract2;  ///< ��Լ2����
    TEsDirectType				Direct;     ///< ��������
    TEsHedgeType				Hedge;      ///< Ͷ����ʶ
    TEsTradePriceType			HoldPrice;  ///< �ֲּ۸�
    TEsTradeVolType				HoldVol;    ///< �ֲ�����
    TEsDateType					HoldDate;   ///< �ֲ�ʱ��
    TEsHoldKey                  HoldKey;    ///< �ֲ�Ψһ��ʶ���յ�Ӧ�����ظ���¼�����һ��Ϊ׼
};

///��ѯ������״̬Ӧ����
struct TEsExchangeStateRspField
{
    TEsExchangeType				Exchange;           ///< ������
    TEsExchangeStateType		ExchangeState;      ///< �г�״̬�����TEsExchangeStateType����
    TEsDateTimeType				ExchangeDateTime;   ///< ������ϵͳʱ��
};

///��Ʒ��ѯӦ����
struct TEsCommodityRspField
{
    TEsExchangeType				Exchange;   ///< ������
    TEsCommodityType			Commodity;  ///< ��Ʒ����
    TEsCommodityNameType		Name;       ///< ��Ʒ����
    TEsCommodityDotType			Dot;        ///< ��Ʒÿ�ֳ���
    TEsCommodityTickType		Tick;	    ///< ��Ʒ��С�䶯��	
};

///��Լ��ѯӦ����
struct TEsContractRspField
{
    TEsExchangeType				Exchange;       ///< ������
    TEsContractType				Contract;       ///< ��Լ����
    TEsContractNameType			Name;           ///< ��Լ��������
    TEsDateType					BeginTradeDay;  ///< ��ʼ������
    TEsDateType					EndTradeDay;    ///< ����������
    TEsDateType					DeliveryDay;    ///< ������
};

///��Ϻ�Լ��ѯӦ����
struct TEsCmbContractRspField
{
    TEsExchangeType				Exchange;   ///<������
    TEsCmbTypeType				CmbType;    ///<�������
    TEsContractType				Contract1;  ///<��Լ1����
    TEsContractType				Contract2;  ///<��Լ2����
};

///��������������
struct TEsQuoteReqField
{
    TEsExchangeType				Exchange;   ///<������
    TEsCmbTypeType				CmbType;    ///<�������
    TEsContractType				Contract1;  ///<��Լ1����
    TEsContractType				Contract2;  ///<��Լ2����
    TEsSubQuoteType				SubQuote;   ///<����ȡ����ʶ
};

///��Լ������Ϣ��
struct TEsQuoteRspField
{
    TEsExchangeType				Exchange;       ///<������
    TEsContractType				Contract;       ///<��Լ����

    TEsQuotePriceType			YClose;			///<������
    TEsQuotePriceType			YSettle;		///<�����
    TEsQuotePriceType			Open;			///<���̼�
    TEsQuotePriceType			High;			///<��߼�
    TEsQuotePriceType			Low;			///<��ͼ�
    TEsQuotePriceType			New;			///<���¼�
    TEsQuotePriceType			Settle;			///<�����
    TEsQuotePriceType			AvgPrice;		///<ƽ����
    TEsQuoteVolType				Volume;			///<�ɽ���
    TEsQuoteVolType				Amount;			///<�ֲ���

    TEsQuotePriceType			Buy;			///<�����
    TEsQuoteVolType				BuyVol;			///<������
    TEsQuotePriceType			Sell;			///<������
    TEsQuoteVolType				SellVol;		///<������				

    TEsQuotePriceType			LimitUp;		///<��ͣ��
    TEsQuotePriceType			LimitDown;		///<��ͣ��
};

///��Ϻ�Լ������Ϣ��
struct TEsCmbQuoteRspField
{
    TEsExchangeType				Exchange;   ///<������
    TEsCmbTypeType				CmbType;    ///<�������
    TEsContractType				Contract1;  ///<��Լ1����
    TEsContractType				Contract2;  ///<��Լ2����

    TEsQuotePriceType			Buy;			///<����ۣ�֣�ݴ����������������ֶ�
    TEsQuoteVolType				BuyVol;			///<��������֣�ݴ����������������ֶ�
    TEsQuotePriceType			Sell;			///<�����ۣ�֣�ݴ����������������ֶ�
    TEsQuoteVolType				SellVol;		///<��������֣�ݴ����������������ֶ�

    TEsQuoteVolType				AllBuyVol;		///<��������֣�ݽ������������ֶ�
    TEsQuoteVolType				AllSellVol;		///<��������֣�ݽ������������ֶ�

    TEsQuotePriceType			DeriveBuy;			///<����ۣ��ǽ�������������ʢ��������������
    TEsQuoteVolType				DeriveBuyVol;		///<���������ǽ�������������ʢ��������������
    TEsQuotePriceType			DeriveSell;			///<�����ۣ��ǽ�������������ʢ��������������
    TEsQuoteVolType				DeriveSellVol;		///<���������ǽ�������������ʢ��������������

};

#endif