// TEWrapper.cpp : 定义 DLL 应用程序的导出函数。

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

//公共接口
extern "C"
{


  /*
  //创建API
  WIN32_API void* CreateTradeApi()
  {
    return CreateEsunnyTradeApi();
  };
  //创建API
  WIN32_API void* CreateQuoteApi()
  {
    return CreateEsunnyQuoteApi();
  };
  */

  //处理函数
  WIN32_API int Process(void *instance, int mode, void* req)
  {
    switch(mode)
    {

      //认证函数 认证码 针对每个开发商 一个
    case 0:
      {
        TEsCertInfoType cert;

        memcpy(&cert,req,sizeof(cert));
        TEsLogPathType path;

        return CertEsunnyApi(cert, path);
      }
      //获取版本  当前版本  0.3
    case 1:
      {
        GetEsunnyApiVersion((char*)req);

        return 0;
      }

    case 2://创建交易API
      {
        return (int)CreateEsunnyTradeApi();
      }
    case 3://创建行情API
      {
        return (int)CreateEsunnyQuoteApi();
      }
    case 4://创建交易回调
      {
        EsunnyTradeSpiCallbackStruct callback;
        memcpy(&callback,req,sizeof(callback));
        EsunnyTradeSpi *spi = new EsunnyTradeSpi(callback);
        return (int)spi; 
      }
    case 5://创建行情回调
      {
        EsunnyQuoteSpiCallbackStruct callback;
        memcpy(&callback,req,sizeof(callback));
        EsunnyQuoteSpi *spi = new EsunnyQuoteSpi(callback);
        return (int)spi; 
      }

    case 101://设置回调数据接口
      {
        ((IEsunnyTradeApi *)instance)->SetSpi((IEsunnyTradeSpi*)req);

        return 0;
      }
    case 102://释放当前api会话
      {
        ((IEsunnyTradeApi *)instance)->Free();
        return 0;
      }
    case 103://连接交易服务
      {
        TEsAddressField addr;
        memcpy(&addr,req,sizeof(addr));
        return ((IEsunnyTradeApi *)instance)->Open(addr);
      }
    case 104://关闭交易服务
      {
        ((IEsunnyTradeApi *)instance)->Close();
        return 0;
      }
    case 105://是否连接
      {
        return ((IEsunnyTradeApi *)instance)->IsOpen();
      }

    case 201://设置回调数据接口
      {
        ((IEsunnyQuoteApi *)instance)->SetSpi((IEsunnyQuoteSpi*)req);

        return 0;
      }
    case 202://释放当前api会话
      {
        ((IEsunnyQuoteApi *)instance)->Free();
        return 0;
      }
    case 203://连接交易服务
      {
        TEsAddressField addr;
        memcpy(&addr,req,sizeof(addr));
        return ((IEsunnyQuoteApi *)instance)->Open(addr);
      }
    case 204://关闭交易服务
      {
        ((IEsunnyQuoteApi *)instance)->Close();
        return 0;
      }
    case 205://是否连接
      {
        return ((IEsunnyQuoteApi *)instance)->IsOpen();
      }



    case 1006://登录操作
      {

        TEsLoginReqField data;
        memcpy(&data,req,sizeof(data));

        return ((IEsunnyTradeApi *)instance)->Login(data);
      }
    case 1007://修改个人密码
      {

        TEsSetPassReqField data;
        memcpy(&data,req,sizeof(data));

        return ((IEsunnyTradeApi *)instance)->SetPass(data);
      }
    case 1008://登录成功后 方可获取交易日期
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


    case 1201://查询客户资金
      {
        return ((IEsunnyTradeApi *)instance)->QryMoney();
      }
    case 1202://查询客户委托 查询所有数据 流号填0
      {
        return ((IEsunnyTradeApi *)instance)->QryOrder((TEsStreamIDType)req);
      }
    case 1203://查询客户成交 查询所有数据 流号填0
      {
        return ((IEsunnyTradeApi *)instance)->QryMatch((TEsStreamIDType)req);
      };
    case 1204://查询持仓 包含组合持仓和单腿持仓
      {
        return ((IEsunnyTradeApi *)instance)->QryHold();
      };

    case 1301:	//报单请求
      {
        TEsOrderInsertReqField data;
        memcpy(&data,req,sizeof(data));
        return ((IEsunnyTradeApi *)instance)->OrderInsert(data);
      };
    case 1302 : //报单操作
      {
        TEsOrderActionReqField data;
        memcpy(&data,req,sizeof(data));
        return ((IEsunnyTradeApi *)instance)->OrderAction(data);
      };

      /*
       行情接口部分
      */
     case 2101 : //订阅行情
      {
        TEsQuoteReqField data;
        memcpy(&data,req,sizeof(data));
        return ((IEsunnyQuoteApi *)instance)->SubQuote(data);
      };
      case 2102 : //订阅行情
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
//交易接口
extern "C"
{

  //设置回调数据接口
  WIN32_API void TradeSetSpi(void *instance,IEsunnyTradeSpi* spi)
  {
    ((IEsunnyTradeApi *)instance)->SetSpi(spi);
  };
  //释放当前api会话
  WIN32_API void TradeFree(void *instance)
  {
    ((IEsunnyTradeApi *)instance)->Free();
  };

  //连接交易服务
  WIN32_API bool TradeOpen(void *instance,TEsAddressField addr)
  {
    return ((IEsunnyTradeApi *)instance)->Open(addr);
  };
  //关闭交易服务
  WIN32_API void TradeClose(void *instance)
  {
    ((IEsunnyTradeApi *)instance)->Close();
  };
  //是否连接
  WIN32_API bool TradeIsOpen(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->IsOpen();
  };

  //登录请求
  WIN32_API int Login(void *instance,TEsLoginReqField req)
  {
    return ((IEsunnyTradeApi *)instance)->Login(req);
  };
  //登录成功后 方可获取交易日期
  WIN32_API void GetTradingDay(void *instance,TEsDateTimeType day)
  {
    ((IEsunnyTradeApi *)instance)->GetTradingDay(day);
  };
  //修改个人密码
  WIN32_API int SetPass(void *instance,TEsSetPassReqField req)
  {
    return ((IEsunnyTradeApi *)instance)->SetPass(req);
  };
  //查询交易员下属客户
  WIN32_API int QryClients(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryClients();
  };


  //查询转账客户
  WIN32_API int QryBankClients(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryBankClients();
  };
  //查询转账流水
  WIN32_API int QryBankCash(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryBankCash();
  };
  //转账操作
  WIN32_API int BankTrade(void *instance,TEsBankCashReqField req)
  {
    return ((IEsunnyTradeApi *)instance)->BankTrade(req);
  };

  //查询客户资金
  WIN32_API int QryMoney(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryMoney();
  };
  //查询客户委托 查询所有数据 流号填0
  WIN32_API int QryOrder(void *instance,TEsStreamIDType streamid)
  {
    return ((IEsunnyTradeApi *)instance)->QryOrder(streamid);
  };
  //查询客户成交 查询所有数据 流号填0
  WIN32_API int QryMatch(void *instance,TEsStreamIDType streamid)
  {
    return ((IEsunnyTradeApi *)instance)->QryMatch(streamid);
  };
  //查询持仓 包含组合持仓和单腿持仓
  WIN32_API int QryHold(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryHold();
  };

  //查询交易所状态  包括交易所时间
  WIN32_API int QryExchangeState(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryExchangeState();
  };
  //查询交易商品
  WIN32_API int QryCommodity(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryCommodity();
  };
  //查询单腿合约
  WIN32_API int QryContract(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryContract();
  };
  //查询组合合约
  WIN32_API int QryCmbContract(void *instance)
  {
    return ((IEsunnyTradeApi *)instance)->QryCmbContract();
  };

  //报单请求
  WIN32_API int OrderInsert(void *instance,TEsOrderInsertReqField req)
  {
    return ((IEsunnyTradeApi *)instance)->OrderInsert(req);
  };
  //报单操作
  WIN32_API int OrderAction(void *instance,TEsOrderActionReqField req)
  {
    return ((IEsunnyTradeApi *)instance)->OrderAction(req);
  };
}

//行情接口
extern "C"
{
  //设置回调数据接口
  WIN32_API void QuoteSetSpi(void *instance,IEsunnyQuoteSpi* spi)
  {
    ((IEsunnyQuoteApi *)instance)->SetSpi(spi);
  };
  //释放当前api会话
  WIN32_API void QuoteFree(void *instance)
  {
    ((IEsunnyQuoteApi *)instance)->Free();
  };

  //连接交易服务
  WIN32_API bool QuoteOpen(void *instance,TEsAddressField& addr)
  {
    return ((IEsunnyQuoteApi *)instance)->Open(addr);
  };
  //关闭交易服务
  WIN32_API void QuoteClose(void *instance)
  {
    ((IEsunnyQuoteApi *)instance)->Close();
  };
  //是否连接
  WIN32_API bool QuoteIsOpen(void *instance)
  {
    return ((IEsunnyQuoteApi *)instance)->IsOpen();
  };


  //行情订阅
  WIN32_API bool SubQuote(void *instance, TEsQuoteReqField& req)
  {
    return ((IEsunnyQuoteApi *)instance)->SubQuote(req);
  };

  //行情获取
  WIN32_API bool GetQuote(void *instance, TEsQuoteRspField& data)
  {
    return ((IEsunnyQuoteApi *)instance)->GetQuote(data);
  };
  WIN32_API bool GetCmbQuote(void *instance, TEsCmbQuoteRspField& data)
  {
    return ((IEsunnyQuoteApi *)instance)->GetCmbQuote(data);
  };
}

//回调
extern "C"
{
  //回调数据接口
  WIN32_API void* CreateTradeSpi(EsunnyTradeSpiCallbackStruct callback)
  {
    EsunnyTradeSpi *spi = new EsunnyTradeSpi(callback);
    return (void*)spi; 
  };
  //回调数据接口
  WIN32_API void* CreateQuoteSpi(EsunnyQuoteSpiCallbackStruct callback)
  {
    EsunnyQuoteSpi *spi = new EsunnyQuoteSpi(callback);
    return (void*)spi; 
  };
}
*/