#include "StdAfx.h"
#include "PLCCassetteInfoCommand.h"

using namespace PLC;

CPLCCassetteInfoCommand::CPLCCassetteInfoCommand(void)
{
	memset(&m_stCassetteInfoCmd, 0x00, sizeof(CassetteInfo));
	memset(&m_szData, 0x00, sizeof(m_szData));
}

CPLCCassetteInfoCommand::~CPLCCassetteInfoCommand(void)
{
}

void CPLCCassetteInfoCommand::GetData(char * szOutData)
{
	nIndex = 0;
	MakeCassetteInfoCmd(nIndex);
	memcpy(szOutData, m_szData, sizeof(m_szData));
}

void CPLCCassetteInfoCommand::MakeCassetteInfoCmd(int &nIndex)
{
	char szBuf[100];
	nIndex = 0;
	int i=0;

	// ProcessID
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szProcessID, strlen(m_stCassetteInfoCmd.szProcessID));
	memcpy(&m_szData[nIndex], szBuf, 20);
	nIndex += 20;

	// ProductID
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szProductID, strlen(m_stCassetteInfoCmd.szProductID));
	memcpy(&m_szData[nIndex], szBuf, 20);
	nIndex += 20;

	// StepID
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szStepID, strlen(m_stCassetteInfoCmd.szStepID));
	memcpy(&m_szData[nIndex], szBuf, 12);
	nIndex += 12;

	// szBatchID
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szBatchID, strlen(m_stCassetteInfoCmd.szBatchID));
	memcpy(&m_szData[nIndex], szBuf, 12);
	nIndex += 12;

	// Prod_Type
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szProd_Type, strlen(m_stCassetteInfoCmd.szProd_Type));
	memcpy(&m_szData[nIndex], szBuf, 2);
	nIndex += 2;

	// Prod_Kind
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szProd_Kind, strlen(m_stCassetteInfoCmd.szProd_Kind));
	memcpy(&m_szData[nIndex], szBuf, 2);
	nIndex += 2;

	// PPID
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szPPID, strlen(m_stCassetteInfoCmd.szPPID));
	memcpy(&m_szData[nIndex], szBuf, 16);
	nIndex += 16;

	// FlowID
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szFlowID, strlen(m_stCassetteInfoCmd.szFlowID));
	memcpy(&m_szData[nIndex], szBuf, 4);
	nIndex += 4;


	// Panel_Size
	for(i=0; i<2; i++)
	{
		memcpy(&m_szData[nIndex], &m_stCassetteInfoCmd.nPanel_Size[i], 2);
		nIndex += 2;
	}

	// Thickness
	memcpy(&m_szData[nIndex], &m_stCassetteInfoCmd.nThickness, sizeof(m_stCassetteInfoCmd.nThickness));
	nIndex += 2;

	// Comp_Count
	memcpy(&m_szData[nIndex], &m_stCassetteInfoCmd.nComp_Count, sizeof(m_stCassetteInfoCmd.nComp_Count));
	nIndex += 2;

	// nPanel_State
	memcpy(&m_szData[nIndex], &m_stCassetteInfoCmd.nPanel_State, sizeof(m_stCassetteInfoCmd.nPanel_State));
	nIndex += 2;

	// Reading_Flag
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szReading_Flag, strlen(m_stCassetteInfoCmd.szReading_Flag));
	memcpy(&m_szData[nIndex], szBuf, 2);
	nIndex += 2;

	// Ins_Flag;		    
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szIns_Flag, strlen(m_stCassetteInfoCmd.szIns_Flag));
	memcpy(&m_szData[nIndex], szBuf, 2);
	nIndex += 2;
	
	// Panel_Position; 
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szPanel_Position, strlen(m_stCassetteInfoCmd.szPanel_Position));
	memcpy(&m_szData[nIndex], szBuf, 2);
	nIndex += 2;
	
	// Judgement;
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szJudgement, strlen(m_stCassetteInfoCmd.szJudgement));
	memcpy(&m_szData[nIndex], szBuf, 4);
	nIndex += 4;	
	
	// Code
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szCode, strlen(m_stCassetteInfoCmd.szCode));
	memcpy(&m_szData[nIndex], szBuf, 4);
	nIndex += 4;	
	
	// Flow_History
	for(i=0; i<28; i++)
	{
		memcpy(&m_szData[nIndex], &m_stCassetteInfoCmd.nFlow_History[i], 1);
		nIndex += 1;
	}

	// Count1;
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szCount1, strlen(m_stCassetteInfoCmd.szCount1));
	memcpy(&m_szData[nIndex], szBuf, 2);
	nIndex += 2;

	// Count2;
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szCount2, strlen(m_stCassetteInfoCmd.szCount2));
	memcpy(&m_szData[nIndex], szBuf, 2);
	nIndex += 2;

	// Grade;
	for(i=0; i<8; i++)
	{
		memcpy(&m_szData[nIndex], &m_stCassetteInfoCmd.nGrade[i], 1);
		nIndex += 1;
	}

	// Multi_Use;
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szMulti_Use, strlen(m_stCassetteInfoCmd.szMulti_Use));
	memcpy(&m_szData[nIndex], szBuf, 20);
	nIndex += 20;

	// GlassDataBitSignal
	for(i=0; i<4; i++)
	{
		memcpy(&m_szData[nIndex], &m_stCassetteInfoCmd.nGlassDataBitSignal[i], 1);
		nIndex += 1;
	}
	
	// Pair_H_PanelID;
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szPair_H_PanelID, strlen(m_stCassetteInfoCmd.szPair_H_PanelID));
	memcpy(&m_szData[nIndex], szBuf, 12);
	nIndex += 12;

	// Pair_E_PanelID;
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szPair_E_PanelID, strlen(m_stCassetteInfoCmd.szPair_E_PanelID));
	memcpy(&m_szData[nIndex], szBuf, 12);
	nIndex += 12;

	// Pair_ProductID;
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szPair_ProductID, strlen(m_stCassetteInfoCmd.szPair_ProductID));
	memcpy(&m_szData[nIndex], szBuf, 20);
	nIndex += 20;

	// Pair_Grade;
	for(i=0; i<8; i++)
	{
		memcpy(&m_szData[nIndex], &m_stCassetteInfoCmd.nPair_Grade[i], 1);
		nIndex += 1;
	}

	// Flow_Group;
	for(i=0; i<10; i++)
	{
		memcpy(&m_szData[nIndex], &m_stCassetteInfoCmd.nFlow_Group[i], 2);
		nIndex += 2;
	}

	// DBR_Recipe
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szDBR_Recipe, strlen(m_stCassetteInfoCmd.szDBR_Recipe));
	memcpy(&m_szData[nIndex], szBuf, 4);
	nIndex += 4;

	// Reserved
	nIndex +=16;

	// ReferData
	memset(szBuf, ' ', sizeof(szBuf));
	memcpy(szBuf, m_stCassetteInfoCmd.szReferData, strlen(m_stCassetteInfoCmd.szReferData));
	memcpy(&m_szData[nIndex], szBuf, 4);
	nIndex += 4;
}
void CPLCCassetteInfoCommand::SetCassetteInfoCmd(CassetteInfo &stCassetteInfoCmd)
{
	memcpy(&m_stCassetteInfoCmd, &stCassetteInfoCmd, sizeof(CassetteInfo));
}
