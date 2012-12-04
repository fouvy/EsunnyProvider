// TEWrapper.cpp : ���� DLL Ӧ�ó���ĵ���������

#include <windows.h>
#include <tchar.h>
#include <iostream>
#include "..\include\stdafx.h"
#include "..\include\EsunnySpi.h"

using namespace std;

BOOL APIENTRY DllMain( HMODULE hModule,
  DWORD  ul_reason_for_call,
  LPVOID lpReserved
  )
{
  switch (ul_reason_for_call)
  {
  case DLL_PROCESS_ATTACH:
  case DLL_THREAD_ATTACH:
  case DLL_THREAD_DETACH:
  case DLL_PROCESS_DETACH:
    break;
  }
  return TRUE;
}

//�����ӿ�
extern "C"
{


  /*
  //����API
  WIN32_API void* CreateTradeApi()
  {
    return CreateEsunnyTradeApi();
  };
  //����API
  WIN32_API void* CreateQuoteApi()
  {
    return CreateEsunnyQuoteApi();
  };
  */

  //������
  WIN32_API int Process(void *instance, int mode, void* req)
  {
    switch(mode)
    {

      //��֤���� ��֤�� ���ÿ�������� һ��
    case 0:
      {
        TEsCertInfoType cert;

        memcpy(&cert,req,sizeof(cert));
        TEsLogPathType path;

        return CertEsunnyApi(cert, path);
      }
      //��ȡ�汾  ��ǰ�汾  0.3
    case 1:
      {
        GetEsunnyApiVersion((char*)req);

        return 0;
      }

    case 2://��������API
      {
        return (int)CreateEsunnyTradeApi();
      }
    case 3://��������API
      {
        return (int)CreateEsunnyQuoteApi();
      }
    case 4://�������׻ص�
      {
        EsunnyTradeSpiCallbackStruct callback;
        memcpy(&callback,req,sizeof(callback));
        EsunnyTradeSpi *spi = new EsunnyTradeSpi(callback);
        return (int)spi; 
      }
    case 5://��������ص�
      {
        EsunnyQuoteSpiCallbackStruct callback;
        memcpy(&callback,req,sizeof(callback));
        EsunnyQuoteSpi *spi = new EsunnyQuoteSpi(callback);
        return (int)spi; 
      }

    case 101://���ûص����ݽӿ�
      {
        ((IEsunnyTradeApi *)instance)->SetSpi((IEsunnyTradeSpi*)req);

        return 0;
      }
    case 102://�ͷŵ�ǰapi�Ự
      {
        ((IEsunnyTradeApi *)instance)->Free();
        return 0;
      }
    case 103://���ӽ��׷���
      {
        TEsAddressField addr;
        memcpy(&addr,req,sizeof(addr));
        return ((IEsunnyTradeApi *)instance)->Open(addr);
      }
    case 104://�رս��׷���
      {
        ((IEsunnyTradeApi *)instance)->Close();
        return 0;
      }
    case 105://�Ƿ�����
      {
        return ((IEsunnyTradeApi *)instance)->IsOpen();
      }

    case 201://���ûص����ݽӿ�
      {
        ((IEsunnyQuoteApi *)instance)->SetSpi((IEsunnyQuoteSpi*)req);

        return 0;
      }
    case 202://�ͷŵ�ǰapi�Ự
      {
        ((IEsunnyQuoteApi *)instance)->Free();
        return 0;
      }
    case 203://���ӽ��׷���
      {
        TEsAddressField addr;
        memcpy(&addr,req,sizeof(addr));
        return ((IEsunnyQuoteApi *)instance)->Open(addr);
      }
    case 204://�رս��׷���
      {
        ((IEsunnyQuoteApi *)instance)->Close();
        return 0;
      }
    case 205://�Ƿ�����
      {
        return ((IEsunnyQuoteApi *)instance)->IsOpen();
      }



    case 1006://��¼����
      {

        TEsLoginReqField data;
        memcpy(&data,req,sizeof(data));

        return ((IEsunnyTradeApi *)instance)->Login(data);
      }
    case 1007://�޸ĸ�������
      {

        TEsSetPassReqField data;
        memcpy(&data,req,sizeof(data));

        return ((IEsunnyTradeApi *)instance)->SetPass(data);
      }
    case 1008://��¼�ɹ��� ���ɻ�ȡ��������
      {

        TEsDateTimeType data;

        return ((IEsunnyTradeApi *)instance)->GetTradingDay((char*)req);
      }

    case 1101:
      {
        return ((IEsunnyTradeApi *)instance)->QryExchangeState();
      }
    case 1102:
      {
        return ((IEsunnyTradeApi *)instance)->QryCommodity();
      }
    case 1103:
      {
        return ((IEsunnyTradeApi *)instance)->QryContract();
      }
    case 1104:
      {
        return ((IEsunnyTradeApi *)instance)->QryCmbContract();
      }


    case 1201://��ѯ�ͻ��ʽ�
      {
        return ((IEsunnyTradeApi *)instance)->QryMoney();
      }
    case 1202://��ѯ�ͻ�ί�� ��ѯ�������� ������0
      {
        return ((IEsunnyTradeApi *)instance)->QryOrder((TEsStreamIDType)req);
      }
    case 1203://��ѯ�ͻ��ɽ� ��ѯ�������� ������0
      {
        return ((IEsunnyTradeApi *)instance)->QryMatch((TEsStreamIDType)req);
      };
    case 1204://��ѯ�ֲ� ������ϳֲֺ͵��ȳֲ�
      {
        return ((IEsunnyTradeApi *)instance)->QryHold();
      };

    case 1301:	//��������
      {
        TEsOrderInsertReqField data;
        memcpy(&data,req,sizeof(data));
        return ((IEsunnyTradeApi *)instance)->OrderInsert(data);
      };
    case 1302 : //��������
      {
        TEsOrderActionReqField data;
        memcpy(&data,req,sizeof(data));
        return ((IEsunnyTradeApi *)instance)->OrderAction(data);
      };

      /*
       ����ӿڲ���
      */
     case 2101 : //��������
      {
        TEsQuoteReqField data;
        memcpy(&data,req,sizeof(data));
        return ((IEsunnyQuoteApi *)instance)->SubQuote(data);
      };
      case 2102 : //��������
      {
        TEsCmbQuoteRspField data;
        memcpy(&data,req,sizeof(data));
        return ((IEsunnyQuoteApi *)instance)->GetCmbQuote(data);
      };

    default:        
      break;
    }

    return 0;
  };
}

/*
//���׽ӿ�
extern "C"
{

  //���ûص����ݽӿ�
  WIN32_API void TradeSetSpi(void *instance,IEsunnyTradeSpi* spi)
  {
    ((IEsunnyTradeApi *)instance)->SetSpi(spi);
  };
  //�ͷŵ�ǰapi�Ự
  WIN32_API void TradeFree(void *instance)
  {
    ((IEsunnyTradeApi *)instance)->Free();
  };

  //���ӽ��׷���
  WIN32_API bool TradeOpen(void *instance,TEsAddressField addr)
  {
    return ((IEsunnyTradeApi *)instance)->Open(addr);
  };
  //�رս��׷���
  WIN32_API void TradeClose(void *instance)
  {
    ((IEsunnyTradeApi *)instance)->Close();
  };
  //�Ƿ�����
  WIN32_API bool TradeIsOpen(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->IsOpen();
  };

  //��¼����
  WIN32_API int Login(void *instance,TEsLoginReqField req)
  {
    return ((IEsunnyTradeApi *)instance)->Login(req);
  };
  //��¼�ɹ��� ���ɻ�ȡ��������
  WIN32_API void GetTradingDay(void *instance,TEsDateTimeType day)
  {
    ((IEsunnyTradeApi *)instance)->GetTradingDay(day);
  };
  //�޸ĸ�������
  WIN32_API int SetPass(void *instance,TEsSetPassReqField req)
  {
    return ((IEsunnyTradeApi *)instance)->SetPass(req);
  };
  //��ѯ����Ա�����ͻ�
  WIN32_API int QryClients(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryClients();
  };


  //��ѯת�˿ͻ�
  WIN32_API int QryBankClients(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryBankClients();
  };
  //��ѯת����ˮ
  WIN32_API int QryBankCash(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryBankCash();
  };
  //ת�˲���
  WIN32_API int BankTrade(void *instance,TEsBankCashReqField req)
  {
    return ((IEsunnyTradeApi *)instance)->BankTrade(req);
  };

  //��ѯ�ͻ��ʽ�
  WIN32_API int QryMoney(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryMoney();
  };
  //��ѯ�ͻ�ί�� ��ѯ�������� ������0
  WIN32_API int QryOrder(void *instance,TEsStreamIDType streamid)
  {
    return ((IEsunnyTradeApi *)instance)->QryOrder(streamid);
  };
  //��ѯ�ͻ��ɽ� ��ѯ�������� ������0
  WIN32_API int QryMatch(void *instance,TEsStreamIDType streamid)
  {
    return ((IEsunnyTradeApi *)instance)->QryMatch(streamid);
  };
  //��ѯ�ֲ� ������ϳֲֺ͵��ȳֲ�
  WIN32_API int QryHold(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryHold();
  };

  //��ѯ������״̬  ����������ʱ��
  WIN32_API int QryExchangeState(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryExchangeState();
  };
  //��ѯ������Ʒ
  WIN32_API int QryCommodity(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryCommodity();
  };
  //��ѯ���Ⱥ�Լ
  WIN32_API int QryContract(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryContract();
  };
  //��ѯ��Ϻ�Լ
  WIN32_API int QryCmbContract(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryCmbContract();
  };

  //��������
  WIN32_API int OrderInsert(void *instance,TEsOrderInsertReqField req)
  {
    return ((IEsunnyTradeApi *)instance)->OrderInsert(req);
  };
  //��������
  WIN32_API int OrderAction(void *instance,TEsOrderActionReqField req)
  {
    return ((IEsunnyTradeApi *)instance)->OrderAction(req);
  };
}

//����ӿ�
extern "C"
{
  //���ûص����ݽӿ�
  WIN32_API void QuoteSetSpi(void *instance,IEsunnyQuoteSpi* spi)
  {
    ((IEsunnyQuoteApi *)instance)->SetSpi(spi);
  };
  //�ͷŵ�ǰapi�Ự
  WIN32_API void QuoteFree(void *instance)
  {
    ((IEsunnyQuoteApi *)instance)->Free();
  };

  //���ӽ��׷���
  WIN32_API bool QuoteOpen(void *instance,TEsAddressField& addr)
  {
    return ((IEsunnyQuoteApi *)instance)->Open(addr);
  };
  //�رս��׷���
  WIN32_API void QuoteClose(void *instance)
  {
    ((IEsunnyQuoteApi *)instance)->Close();
  };
  //�Ƿ�����
  WIN32_API bool QuoteIsOpen(void *instance)
  {
    return ((IEsunnyQuoteApi *)instance)->IsOpen();
  };


  //���鶩��
  WIN32_API bool SubQuote(void *instance, TEsQuoteReqField& req)
  {
    return ((IEsunnyQuoteApi *)instance)->SubQuote(req);
  };

  //�����ȡ
  WIN32_API bool GetQuote(void *instance, TEsQuoteRspField& data)
  {
    return ((IEsunnyQuoteApi *)instance)->GetQuote(data);
  };
  WIN32_API bool GetCmbQuote(void *instance, TEsCmbQuoteRspField& data)
  {
    return ((IEsunnyQuoteApi *)instance)->GetCmbQuote(data);
  };
}

//�ص�
extern "C"
{
  //�ص����ݽӿ�
  WIN32_API void* CreateTradeSpi(EsunnyTradeSpiCallbackStruct callback)
  {
    EsunnyTradeSpi *spi = new EsunnyTradeSpi(callback);
    return (void*)spi; 
  };
  //�ص����ݽӿ�
  WIN32_API void* CreateQuoteSpi(EsunnyQuoteSpiCallbackStruct callback)
  {
    EsunnyQuoteSpi *spi = new EsunnyQuoteSpi(callback);
    return (void*)spi; 
  };
}
*/