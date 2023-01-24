#include "StdAfx.h"
#include "CPLCPanelIDInfo.h"


using namespace PLC;

CPLCPanelIDInfo::CPLCPanelIDInfo(void)
{
	memset(&m_stPanelIDInfo1, 0x00, sizeof(PanelIDInfo));
	memset(&m_stPanelIDInfo2, 0x00, sizeof(PanelIDInfo));
	memset(&m_stPanelIDInfo3, 0x00, sizeof(PanelIDInfo));
	memset(&m_stPanelIDInfo4, 0x00, sizeof(PanelIDInfo));
	memset(&m_szData, 0x00, sizeof(m_szData));
}

CPLCPanelIDInfo::~CPLCPanelIDInfo(void)
{
}

void CPLCPanelIDInfo::GetData(int nPortNo, char * szOutData)
{
	int nIndex = 0;

	MakePanelIDInfo(nPortNo, nIndex);

	memcpy(szOutData, m_szData, sizeof(m_szData));
}

void CPLCPanelIDInfo::MakePanelIDInfo(int nPortNo, int &nIndex)
{
	char szBuf[20]={0};
	char szTemp[4] = {0};

	switch(nPortNo)
	{
	case 1:
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID Infomation Data- GetData, Port No : %d, PanelID : %s"), m_stPanelIDInfo1.nPort,m_stPanelIDInfo1.szHPanelID);
		//	HPanelID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stPanelIDInfo1.szHPanelID, strlen(m_stPanelIDInfo1.szHPanelID));
		memcpy(&m_szData[nIndex], &szBuf, 12);
		nIndex += 12;

		//	UniqueID
		for(int i=0; i<4; i++)
		{
			memcpy(&m_szData[nIndex], &m_stPanelIDInfo1.nUniqueID[i], 1);
			nIndex += 1;
		}

		// Reserved
		nIndex +=4;
		break;
	case 2:
		nIndex +=20;
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID Infomation Data- GetData, Port No : %d, PanelID : %s"), m_stPanelIDInfo2.nPort,m_stPanelIDInfo2.szHPanelID);
		//	HPanelID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stPanelIDInfo2.szHPanelID, strlen(m_stPanelIDInfo2.szHPanelID));
		memcpy(&m_szData[nIndex], &szBuf, 12);
		nIndex += 12;

		//	UniqueID
		for(int i=0; i<4; i++)
		{
			memcpy(&m_szData[nIndex], &m_stPanelIDInfo2.nUniqueID[i], 1);
			nIndex += 1;
		}

		// Reserved
		nIndex +=4;
		break;
	case 3:
		nIndex +=40;
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID Infomation Data- GetData, Port No : %d, PanelID : %s"), m_stPanelIDInfo3.nPort,m_stPanelIDInfo3.szHPanelID);
		//	HPanelID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stPanelIDInfo3.szHPanelID, strlen(m_stPanelIDInfo3.szHPanelID));
		memcpy(&m_szData[nIndex], &szBuf, 12);
		nIndex += 12;

		//	UniqueID
		for(int i=0; i<4; i++)
		{
			memcpy(&m_szData[nIndex], &m_stPanelIDInfo3.nUniqueID[i], 1);
			nIndex += 1;
		}
		// Reserved
		nIndex +=4;
		break;
	case 4:
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID Infomation Data- GetData, Port No : %d, PanelID : %s"), m_stPanelIDInfo4.nPort,m_stPanelIDInfo4.szHPanelID);
		nIndex +=60;
		//	HPanelID
		memset(szBuf, ' ', sizeof(szBuf));
		memcpy(szBuf, m_stPanelIDInfo4.szHPanelID, strlen(m_stPanelIDInfo4.szHPanelID));
		memcpy(&m_szData[nIndex], &szBuf, 12);
		nIndex += 12;

		//	UniqueID
		for(int i=0; i<4; i++)
		{
			memcpy(&m_szData[nIndex], &m_stPanelIDInfo4.nUniqueID[i], 1);
			nIndex += 1;
		}

		// Reserved
		nIndex +=4;
		break;
	default:
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID Infomation Data- Defualt Eror"));
		//for(int i=0; i<4; i++)
		//{
		//	//	HPanelID
		//	memset(szBuf, ' ', sizeof(szBuf));
		//	memcpy(szBuf, m_stPanelIDInfo.szHPanelID, strlen(m_stPanelIDInfo.szHPanelID));
		//	memcpy(&m_szData[nIndex], &szBuf, 12);
		//	nIndex += 12;

		//	//	UniqueID
		//	for(int i=0; i<4; i++)
		//	{
		//		memcpy(&m_szData[nIndex], &m_stPanelIDInfo.nUniqueID[i], 1);
		//		nIndex += 1;
		//	}
		//	// Reserved
		//	nIndex +=4;
		//}
		//break;
	}
}
void CPLCPanelIDInfo::SetPanelIDInfo(PanelIDInfo &stPanelIDInfo)
{
	switch(stPanelIDInfo.nPort)
	{
	case 1:
		memcpy(&m_stPanelIDInfo1, &stPanelIDInfo, sizeof(PanelIDInfo));
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID Infomation Data- Copy Data, Port No : %d, PanelID : %s"), m_stPanelIDInfo1.nPort,m_stPanelIDInfo1.szHPanelID);
		break;
	case 2:
		memcpy(&m_stPanelIDInfo2, &stPanelIDInfo, sizeof(PanelIDInfo));
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID Infomation Data- Copy Data, Port No : %d, PanelID : %s"), m_stPanelIDInfo2.nPort,m_stPanelIDInfo2.szHPanelID);
		break;
	case 3:
		memcpy(&m_stPanelIDInfo3, &stPanelIDInfo, sizeof(PanelIDInfo));
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID Infomation Data- Copy Data, Port No : %d, PanelID : %s"), m_stPanelIDInfo3.nPort,m_stPanelIDInfo3.szHPanelID);
		break;
	case 4:
		memcpy(&m_stPanelIDInfo4, &stPanelIDInfo, sizeof(PanelIDInfo));
		CUtil::WriteLogFile(CABConfig::g_strLog, _T("PanelID Infomation Data- Copy Data, Port No : %d, PanelID : %s"), m_stPanelIDInfo4.nPort,m_stPanelIDInfo4.szHPanelID);
		break;
	}
}
