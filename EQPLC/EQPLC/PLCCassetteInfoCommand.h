#pragma once

#include "IPLC.h"

namespace PLC
{
	class CPLCCassetteInfoCommand : public IPLC
	{
	public:
		struct CassetteInfo{
			int nPortNo;
			char szProcessID[20];
			char szProductID[20];
			char szStepID[12];
			char szBatchID[12];
			char szProd_Type[2];
			char szProd_Kind[2];
			char szPPID[16];
			char szFlowID[4];
			int nPanel_Size[2];
			int nThickness;
			int nComp_Count;
			int nPanel_State;
			char szReading_Flag[2];
			char szIns_Flag[2];
			char szPanel_Position[2];
			char szJudgement[4];
			char szCode[4];
			short nFlow_History[28];
			char szCount1[2];
			char szCount2[2];
			short nGrade[8];
			char szMulti_Use[20];
			short nGlassDataBitSignal[4];
			char szPair_H_PanelID[12];
			char szPair_E_PanelID[12];
			char szPair_ProductID[20];
			short nPair_Grade[8]; 
			short nFlow_Group[10];
			char szDBR_Recipe[4];
			char szReferData[4];
		};

	public:
		CPLCCassetteInfoCommand(void);
		virtual ~CPLCCassetteInfoCommand(void);

	public:
		virtual void GetData(char * szOutData);
		void SetCassetteInfoCmd(CassetteInfo &stCassetteInfoCmd);
		void MakeCassetteInfoCmd(int &nIndex);
		//void SetCassetteInfo();
		int nIndex;
	private:
		char m_szData[272];
		CassetteInfo m_stCassetteInfoCmd;
	};
}