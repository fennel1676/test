#include "StdAfx.h"
#include "PLCSigWordCommand3.h"

using namespace PLC;

CPLCSigWordCommand3::CPLCSigWordCommand3(void)
{
	memset(m_stECIDCmd, 0x00, sizeof(ECID_INFO) * 15);
	memset(m_szData, 0x00, sizeof(m_szData));
}

CPLCSigWordCommand3::~CPLCSigWordCommand3(void)
{
}

void CPLCSigWordCommand3::GetData(char * szOutData)
{
	int nIndex = 0;

	MakeECIDCmd(nIndex);

	memcpy(szOutData, m_szData, sizeof(m_szData));
}

void CPLCSigWordCommand3::MakeECIDCmd(int &nIndex)
{
	short nBuf = 0;
	//	CommandID
	memcpy(&m_szData[nIndex], &m_nCommandID, 2);
	nIndex += 2;

	//	reserved
	nIndex += 2;

	//	ECID
	for(int i = 0; i < 15; i++)
	{
		//	ECID
		memcpy(&m_szData[nIndex], &m_stECIDCmd[i].nECID, 2);
		nIndex += 2;

		//	reserved
		nIndex += 2;

		//	ECDEF
		memcpy(&m_szData[nIndex], &m_stECIDCmd[i].nECDEF, 4);
		nIndex += 4;

		//	ECSLL
		memcpy(&m_szData[nIndex], &m_stECIDCmd[i].nECSLL, 2);
		nIndex += 2;

		//	ECSUL
		memcpy(&m_szData[nIndex], &m_stECIDCmd[i].nECSUL, 2);
		nIndex += 2;

		//	ECWLL
		memcpy(&m_szData[nIndex], &m_stECIDCmd[i].nECWLL, 2);
		nIndex += 2;

		//	ECWUL
		memcpy(&m_szData[nIndex], &m_stECIDCmd[i].nECWUL, 2);
		nIndex += 2;
	}
}

void CPLCSigWordCommand3::SetECIDCmd(short nCommandID, ECID_INFO *pstECIDCmd)
{
	m_nCommandID = nCommandID;
	memcpy(m_stECIDCmd, pstECIDCmd, sizeof(ECID_INFO) * 15);
}
