#include "StdAfx.h"
#include "PLCGlassData.h"

using namespace PLC;

CPLCGlassData::CPLCGlassData(void)
{
	m_nUnitNo = 1;
}

CPLCGlassData::~CPLCGlassData(void)
{
}

void CPLCGlassData::SetTagName(CString strTagName)
{
	IPLC::SetTagName(strTagName);

	CString strUnitNo;
	AfxExtractSubString(strUnitNo, strTagName, 2, '_');
	strUnitNo.Replace("TransferGlassDataUnit", "");

	m_nUnitNo = atoi(strUnitNo.operator LPCTSTR());
}

void CPLCGlassData::SetData(const char *szTagName, char *pData)
{
	char szBuf[64];
	char szBuf2[64];
	int nIndex = 0;
	unsigned char szBuf1[64];

/////////////////////////////////////////////////////////////////////////////////////
	//	Glass Exist Flag
	int nGlassExistFlag = 0;
	unsigned short nWidth, nHeight;

	memcpy(&nGlassExistFlag, &pData[nIndex], 2);
	nIndex += 2;
	if(m_stGlassData.m_nGlassExistFlag != nGlassExistFlag)
		m_stGlassData.m_bInOut = TRUE;
	else
		m_stGlassData.m_bInOut = FALSE;
	m_stGlassData.m_nGlassExistFlag = nGlassExistFlag;

	//	Event ID
	memcpy(&m_stGlassData.m_nEventID, &pData[nIndex], 2);
	nIndex += 2;

	//	H_PANELID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 12);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strHPanelID = szBuf;
	m_stGlassData.m_strHPanelID.TrimLeft(' ');
	m_stGlassData.m_strHPanelID.TrimRight(' ');
	nIndex += 12;

	//	E_PANELID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 12);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strEPanelID = szBuf;
	m_stGlassData.m_strEPanelID.TrimLeft(' ');
	m_stGlassData.m_strEPanelID.TrimRight(' ');
	nIndex += 12;

	//	ProcessID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 20);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strProcessID = szBuf;
	m_stGlassData.m_strProcessID.TrimLeft(' ');
	m_stGlassData.m_strProcessID.TrimRight(' ');
	nIndex += 20;

	//	ProductID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 20);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strProductID = szBuf;
	m_stGlassData.m_strProductID.TrimLeft(' ');
	m_stGlassData.m_strProductID.TrimRight(' ');
	nIndex += 20;

	//	StepID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 12);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strStepID = szBuf;
	m_stGlassData.m_strStepID.TrimLeft(' ');
	m_stGlassData.m_strStepID.TrimRight(' ');
	nIndex += 12;

	//	BatchID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 12);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strBatchID = szBuf;
	m_stGlassData.m_strBatchID.TrimLeft(' ');
	m_stGlassData.m_strBatchID.TrimRight(' ');
	nIndex += 12;

	//	PROD_TYPE
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 2);
	CUtil::ABPLCStrSwap(szBuf, 2);
	m_stGlassData.m_strProdType = szBuf;
	m_stGlassData.m_strProdType.TrimLeft(' ');
	m_stGlassData.m_strProdType.TrimRight(' ');
	nIndex += 2;

	//	PROD_KIND
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 2);
	CUtil::ABPLCStrSwap(szBuf, 2);
	m_stGlassData.m_strProdKind = szBuf;
	m_stGlassData.m_strProdKind.TrimLeft(' ');
	m_stGlassData.m_strProdKind.TrimRight(' ');
	nIndex += 2;

	//	PPID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 16);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strPPID = szBuf;
	m_stGlassData.m_strPPID.TrimLeft(' ');
	m_stGlassData.m_strPPID.TrimRight(' ');
	nIndex += 16;

	//	FLOWID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strFlowID = szBuf;
	m_stGlassData.m_strFlowID.TrimLeft(' ');
	m_stGlassData.m_strFlowID.TrimRight(' ');
	nIndex += 4;

	//	PANEL_SIZE
	memcpy(&nWidth, &pData[nIndex], 2);
	nIndex += 2;
	memcpy(&nHeight, &pData[nIndex], 2);
	nIndex += 2;
	memset(m_stGlassData.m_szPanelSize, 0x00, sizeof(m_stGlassData.m_szPanelSize));
	sprintf(m_stGlassData.m_szPanelSize, "%d %d", nWidth, nHeight);

	//	THICKNESS
	memcpy(&m_stGlassData.m_nThickness, &pData[nIndex], 2);
	nIndex += 2;

	//	COMP_COUNT
	memcpy(&m_stGlassData.m_nCompCount, &pData[nIndex], 2);
	nIndex += 2;

	//	PANEL_STATE
	memcpy(&m_stGlassData.m_nPanelState, &pData[nIndex], 2);
	nIndex += 2;

	//	READING_FLAG
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 2);
	CUtil::ABPLCStrSwap(szBuf, 2);
	m_stGlassData.m_strReadingFlag = szBuf;
	m_stGlassData.m_strReadingFlag.TrimLeft(' ');
	m_stGlassData.m_strReadingFlag.TrimRight(' ');
	nIndex += 2;

	//	INS_FLAG
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 2);
	CUtil::ABPLCStrSwap(szBuf, 2);
	m_stGlassData.m_strInsFlag = szBuf;
	m_stGlassData.m_strInsFlag.TrimLeft(' ');
	m_stGlassData.m_strInsFlag.TrimRight(' ');
	nIndex += 2;

	//	PANEL_POSITION
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 2);
	CUtil::ABPLCStrSwap(szBuf, 2);
	m_stGlassData.m_strPanelPosition = szBuf;
	m_stGlassData.m_strPanelPosition.TrimLeft(' ');
	m_stGlassData.m_strPanelPosition.TrimRight(' ');
	nIndex += 2;

	//	JUDGEMENT
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strJudgement = szBuf;
	m_stGlassData.m_strJudgement.TrimLeft(' ');
	m_stGlassData.m_strJudgement.TrimRight(' ');
	nIndex += 4;

	//	CODE(JUDGEMENT)
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strJudgementCode = szBuf;
	m_stGlassData.m_strJudgementCode.TrimLeft(' ');
	m_stGlassData.m_strJudgementCode.TrimRight(' ');
	nIndex += 4;

	//	FLOW_HISTORY
	byte byteBuf[28];
	memset(byteBuf, 0x00, sizeof(byteBuf));
	memcpy(byteBuf, &pData[nIndex], 28);
	nIndex += 28;
	memset(m_stGlassData.m_szFlowHistory, 0x00, sizeof(m_stGlassData.m_szFlowHistory));
	sprintf(m_stGlassData.m_szFlowHistory, "%d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d",
		byteBuf[0], byteBuf[1], byteBuf[2], byteBuf[3], byteBuf[4], byteBuf[5], byteBuf[6], byteBuf[7], byteBuf[8], byteBuf[9],
		byteBuf[10], byteBuf[11], byteBuf[12], byteBuf[13], byteBuf[14], byteBuf[15], byteBuf[16], byteBuf[17], byteBuf[18], byteBuf[19],
		byteBuf[20], byteBuf[21], byteBuf[22], byteBuf[23], byteBuf[24], byteBuf[25], byteBuf[26], byteBuf[27]);

	//	UNIQUEID
	memset(szBuf1, 0x00, sizeof(szBuf1));
	memcpy(szBuf1, &pData[nIndex], 4);
	memset(m_stGlassData.m_szUniqueID, 0x00, sizeof(m_stGlassData.m_szUniqueID));
	sprintf(m_stGlassData.m_szUniqueID, "%d %d %d %d", szBuf1[0], szBuf1[1], szBuf1[2], szBuf1[3]);
	nIndex += 4;

	//	COUNT1
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 2);
	CUtil::ABPLCStrSwap(szBuf, 2);
	m_stGlassData.m_strCount1 = szBuf;
	m_stGlassData.m_strCount1.TrimLeft(' ');
	m_stGlassData.m_strCount1.TrimRight(' ');
	nIndex += 2;

	//	COUNT2
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 2);
	CUtil::ABPLCStrSwap(szBuf, 2);
	m_stGlassData.m_strCount2 = szBuf;
	m_stGlassData.m_strCount2.TrimLeft(' ');
	m_stGlassData.m_strCount2.TrimRight(' ');
	nIndex += 2;

	//	GRADE - 64bit array string
	int nGrade[2];
	CString strBuf;
	memcpy(&nGrade[1], &pData[nIndex], 4);
	memset(szBuf, 0x00, sizeof(szBuf));
	_itoa(nGrade[1], szBuf, 2); 
	memset(szBuf2, 0x00, sizeof(szBuf2));
	wsprintf(szBuf2, "%032s", szBuf);
	CUtil::ABPLCBinSwap(szBuf2, strlen(szBuf2));
	memset(m_stGlassData.m_szGrade, 0x00, sizeof(m_stGlassData.m_szGrade));
	strcpy(m_stGlassData.m_szGrade, szBuf2);
	nIndex += 4;
	memcpy(&nGrade[0], &pData[nIndex], 4);
	memset(szBuf, 0x00, sizeof(szBuf));
	_itoa(nGrade[0], szBuf, 2); 
	memset(szBuf2, 0x00, sizeof(szBuf2));
	wsprintf(szBuf2, "%032s", szBuf);
	CUtil::ABPLCBinSwap(szBuf2, strlen(szBuf2));
	strcat(m_stGlassData.m_szGrade, szBuf2);
	nIndex += 4;

	//	MULTI_USE
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 20);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strMultiUse = szBuf;
	m_stGlassData.m_strMultiUse.TrimLeft(' ');
	m_stGlassData.m_strMultiUse.TrimRight(' ');
	nIndex += 20;

	//	Glass Bit Signal - 32bit array string
	int nGlassDataSignal;
	memcpy(&nGlassDataSignal, &pData[nIndex], 4);
	memset(szBuf, 0x00, sizeof(szBuf));
	_itoa(nGlassDataSignal, szBuf, 2); 
	memset(szBuf2, 0x00, sizeof(szBuf2));
	wsprintf(szBuf2, "%032s", szBuf);
	CUtil::ABPLCBinSwap(szBuf2, strlen(szBuf2));
	memset(m_stGlassData.m_szGlassDataSignal, 0x00, sizeof(m_stGlassData.m_szGlassDataSignal));
	strcpy(m_stGlassData.m_szGlassDataSignal, szBuf2);
	nIndex += 4;

	//	PAIR_H_PANELID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 12);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strPairHPanel = szBuf;
	m_stGlassData.m_strPairHPanel.TrimLeft(' ');
	m_stGlassData.m_strPairHPanel.TrimRight(' ');
	nIndex += 12;

	//	PAIR_E_PANELID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 12);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strPairEPanel = szBuf;
	m_stGlassData.m_strPairEPanel.TrimLeft(' ');
	m_stGlassData.m_strPairEPanel.TrimRight(' ');
	nIndex += 12;

	//	PAIR_PRODUCTID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 20);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strPairProductID = szBuf;
	m_stGlassData.m_strPairProductID.TrimLeft(' ');
	m_stGlassData.m_strPairProductID.TrimRight(' ');
	nIndex += 20;

	//	PAIR_GRADE - 64bit array string
	int nPairGrade[2];
	CString strPairBuf;
	memcpy(&nPairGrade[1], &pData[nIndex], 4);
	memset(szBuf, 0x00, sizeof(szBuf));
	_itoa(nPairGrade[1], szBuf, 2); 
	memset(szBuf2, 0x00, sizeof(szBuf2));
	wsprintf(szBuf2, "%032s", szBuf);
	CUtil::ABPLCBinSwap(szBuf2, strlen(szBuf2));
	memset(m_stGlassData.m_szPairGrade, 0x00, sizeof(m_stGlassData.m_szPairGrade));
	strcpy(m_stGlassData.m_szPairGrade, szBuf2);
	nIndex +=4;
	memcpy(&nPairGrade[0], &pData[nIndex], 4);
	memset(szBuf, 0x00, sizeof(szBuf));
	_itoa(nPairGrade[0], szBuf, 2); 
	memset(szBuf2, 0x00, sizeof(szBuf2));
	wsprintf(szBuf2, "%032s", szBuf);
	CUtil::ABPLCBinSwap(szBuf2, strlen(szBuf2));
	strcat(m_stGlassData.m_szPairGrade, szBuf2);
	nIndex += 4;
	/*int nPairGrade[2];
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(&nPairGrade[1], &pData[nIndex], 4);
	_itoa(nPairGrade[1], szBuf, 2); 
	memset(szBuf2, 0x00, sizeof(szBuf2));
	wsprintf(szBuf2, "%032s", szBuf);
	CUtil::ABPLCBinSwap(szBuf2, strlen(szBuf2));
	memset(m_stGlassData.m_szPairGrade, 0x00, sizeof(m_stGlassData.m_szPairGrade));
	strcat(m_stGlassData.m_szPairGrade, szBuf2);
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(&nPairGrade[0], &pData[nIndex], 4);
	_itoa(nPairGrade[0], szBuf, 2); 
	memset(szBuf2, 0x00, sizeof(szBuf2));
	wsprintf(szBuf2, "%032s", szBuf);
	CUtil::ABPLCBinSwap(szBuf2, strlen(szBuf2));
	strcat(m_stGlassData.m_szPairGrade, szBuf2);
	nIndex += 8;*/

	//	FLOW_GROUP
	unsigned short nFlowGroup[10];
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(nFlowGroup, &pData[nIndex], 20);
	memset(m_stGlassData.m_szFlowGroup, 0x00, sizeof(m_stGlassData.m_szFlowGroup));
	sprintf(m_stGlassData.m_szFlowGroup, "%d %d %d %d %d %d %d %d %d %d",
		nFlowGroup[0], nFlowGroup[1], nFlowGroup[2], nFlowGroup[3], nFlowGroup[4],
		nFlowGroup[5], nFlowGroup[6], nFlowGroup[7], nFlowGroup[8], nFlowGroup[9]);
	nIndex += 20;

	//	DBR_RECIPE
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strDBRRecipe = szBuf;
	m_stGlassData.m_strDBRRecipe.TrimLeft(' ');
	m_stGlassData.m_strDBRRecipe.TrimRight(' ');
	nIndex += 4;

	//	Reserved
	nIndex += 16;

	//	Refer Data
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strRefer = szBuf;
	m_stGlassData.m_strRefer.TrimLeft(' ');
	m_stGlassData.m_strRefer.TrimRight(' ');
	nIndex += 4;

	//	Contact Point State
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strContactPointState1 = szBuf;
	m_stGlassData.m_strContactPointState1.TrimLeft(' ');
	m_stGlassData.m_strContactPointState1.TrimRight(' ');
	nIndex += 4;

	//	Contact Point State(Reserved)
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strContactPointState2 = szBuf;
	m_stGlassData.m_strContactPointState2.TrimLeft(' ');
	m_stGlassData.m_strContactPointState2.TrimRight(' ');
	nIndex += 4;

	//	From EQNo
	memcpy(&m_stGlassData.m_nFromEQNo, &pData[nIndex], 2);
	nIndex += 2;

	//	To EQNo
	memcpy(&m_stGlassData.m_nToEQNo, &pData[nIndex], 2);
	nIndex += 2;

	// SlotID
	memset(szBuf, 0x00, sizeof(szBuf));
	memcpy(szBuf, &pData[nIndex], 4);
	CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	m_stGlassData.m_strSlotID = szBuf;
	m_stGlassData.m_strSlotID.TrimLeft(' ');
	m_stGlassData.m_strSlotID.TrimRight(' ');
	nIndex += 2;

	// Reserved
	nIndex +=2;


	////	REFUSE_CODE
	//memset(szBuf, 0x00, sizeof(szBuf));
	//memcpy(szBuf, &pData[nIndex], 4);
	//CUtil::ABPLCStrSwap(szBuf, sizeof(szBuf));
	//m_stGlassData.m_strRefuseCode = szBuf;
	//m_stGlassData.m_strRefuseCode.TrimLeft(' ');
	//m_stGlassData.m_strRefuseCode.TrimRight(' ');
	//nIndex += 4;

	////	H/S Signal BITS Signal
	//memcpy(&m_stGlassData.m_nHSSignalBits, &pData[nIndex], 2);
	//nIndex += 2;

	IPLC::pPLCEvent->EventGlassData(GetPLCNo(), m_nUnitNo, m_stGlassData);
}
