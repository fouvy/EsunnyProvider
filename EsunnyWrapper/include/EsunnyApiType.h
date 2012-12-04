//////////////////////////////////////////////////////////////////////////
/// \file EsunnyApiType.h
/// \brief ��ʢ��̬�����õ��Ļ�����������
/// 
///  ҵ���������õ������ݽṹ�����ɻ�������������϶��ɵ�
//////////////////////////////////////////////////////////////////////////

#ifndef _ESUNNY_API_TYPE_
#define _ESUNNY_API_TYPE_

///��֤��Ϣ
typedef char TEsCertInfoType[201];
///��־·��
typedef char TEsLogPathType[1024];
///API��־���� 0-��¼����API������־ 1-��¼������API������־
typedef int  TEsLogLevel;

///�汾��Ϣ
typedef char TEsVersionType[51];

///ip��ַ����
/*! \var typedef char TEsIpType[21];
 \brief ip��ַ����
*/
typedef char TEsIpType[21];
///�˿�����
typedef int	 TEsPortType;

///����� 0-�ɹ�
typedef int	 TEsErrorCodeType;
///������Ϣ 
typedef char TEsErrorInfoType[51];
///�Ƿ��ѯ����
typedef bool TEsIsLastType;

///����ʱ������  yyyy-MM-dd HH:MM:SS
typedef char TEsDateTimeType[21];
///�������� yyyy-MM-dd
typedef char TEsDateType[11];
///ʱ������ HH:MM:SS
typedef char TEsTimeType[11];

///��Ա��
typedef char TEsMemberNoType[21];
///ϯλ��
typedef char TEsPosNoType[21];

///��¼���� 'C'-���ͻ�,'T'-����Ա
typedef char TEsLoginTypeType;
///��¼��
typedef char TEsLoginNoType[21];
///�ͻ���
typedef char TEsClientNoType[21];
///�ͻ�����
typedef char TEsClientNameType[21];
///����
typedef char TEsPasswordType[21];

///�������� ��ʶί�кͳɽ����ݵ��Ⱥ�˳���Լ���ѯ���ݵ���ʼλ��
typedef int	 TEsStreamIDType;
///������ �ͻ�������,�״�Ӧ�𷵻�, ����״̬���ͨ��ί�кű���
typedef int	 TEsRequestIndexType;
///ί�к�  ���б��� ���׷������ı���  ������ί�к�
typedef char TEsOrderNoType[21];
///���غ�  ͨ�����׷����� ���뽻�����ı���  �����ɱ��غ�
typedef char TEsLocalNoType[21];
///ϵͳ��  ���뽻�����ı��� ������ϵͳ���� ϵͳ��
typedef char TEsSystemNoType[21];

///�ɽ���
typedef char TEsMatchNoType[21];

///ί������ 0-�޼�,1-�м�
typedef int	 TEsOrderTypeType;


/// \brief ί��״̬ 0-��Ч��,1-�µ�,2-���Ŷ�,3-��ȫ�ɽ�,4-��������,5-�ѳ���,6-��,7-��ɾ��,8-�ѷ���,
///9-����,10-���ֳɽ�,11-�ǽ���ʱ��,12-�ʽ���,13-���׹ر�,14-ָ��ʧ��,15-����ʧ��,16-ϵͳ����,
///17-������,18-������ɾ��,19-����,20-����,21-������,22-�Զ���,23-�Զ���ɾ��
typedef int	 TEsOrderStateType; 

///������� 0-����,1-����,2-��Ʒ��
typedef int	 TEsCmbTypeType;

///�г� '1'-֣��,'2'-����,'3'-�Ϻ�,'5'-�н�
typedef char TEsExchangeType;
///��Ʒ����  ���磺���� SR
typedef char TEsCommodityType[21];
///��Ʒ��������
typedef char TEsCommodityNameType[21];
///��Ʒÿ�ֳ���
typedef int	TEsCommodityDotType;
///��Ʒ��С�䶯��
typedef double TEsCommodityTickType;
///��Լ����  ���磺���� SR011
typedef char TEsContractType[21];

///��Լ��������
typedef char TEsContractNameType[21];

///�������� '1'-����,'3'-����
typedef char TEsDirectType;
///��ƽ	'1'-����,'2'-ƽ��(������ƽ��),'3'-ƽ��(������ƽ��)
typedef char TEsOffsetType;
///Ͷ��	'1'-Ͷ��,'3'-��ֵ
typedef char TEsHedgeType;

///��������
typedef int	 TEsTradeVolType;
///���׼۸�
typedef double TEsTradePriceType;

///�ʽ�
typedef double TEsMoneyValueType;

/// \brief �г�״̬ '0'-ϵͳ��ʼ����,'1'-ϵͳ���������Ե�¼,'2'-���̾����뵥�׶�
/// '3'-���̼��Ͼ��۽׶Σ�ֹͣ�뵥��, '4'-�������׽׶Σ����У�,'5'-����������ͣ�׶�
/// '6'-���̾����뵥��ͣ�׶�,'7'-���У����У�,'8'-�Ͽ��뽻��������
typedef char TEsExchangeStateType;

///����۸�
typedef double TEsQuotePriceType;
///��������
typedef int TEsQuoteVolType;
///������������  'S'-����,'C'-ȡ��
typedef char TEsSubQuoteType;

///ת�˷����
typedef char TEsBankGroupNoType[21];
///���б�ʶ '1'-����,'2'-ũ�з���,'3'-ũ������,'4'-����,'5'-����
typedef char TEsBankType;
///�����ʺ�
typedef char TEsBankClientNoType[21];
///���֤��
typedef char TEsPersonIdType[21];
///�ͻ�����
typedef char TEsPersonNameType[21];
///ת��״̬ 'Y'-����,'N'-��ֹ
typedef char TEsBankClientStateType;
///ת�˷��� 'B'-����ת�ڻ� 'F'-�ڻ�ת����
typedef char TEsBankTradeTypeType;
///ת�˽��
typedef double TEsBankMoneyType;
///������ 'B'-���з��� 'F'-�ڻ�����
typedef char TEsBankPackFlagType;
///�������� 1-����ת�ڻ���2-�ڻ�ת���У�11-��������ת�ڻ���12-�����ڻ�ת���У�99-��·���
typedef int	TEsBankTrTradeTypeType;
///ת����ˮ��
typedef char TEsBankSerNo[11];
///ת�˷�����
typedef char TEsBankRetCode[5];

///�ֱֲ�ʶ
typedef char TEsHoldKey[81];


#endif