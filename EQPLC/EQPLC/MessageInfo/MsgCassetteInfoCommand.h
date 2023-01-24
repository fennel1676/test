#pragma once

#include "../MessageInfo.h"

namespace Message
{
	class CMsgCassetteInfoCommand : public IMessageInfo
	{
	public:
		CMsgCassetteInfoCommand(void);
		virtual ~CMsgCassetteInfoCommand(void);

	public:
		virtual const CString GetMsg() { return _T(""); }
		virtual bool ParseMsg(const CString& strXML);

	public:
		int nPortNo;
		CString strProcessID;
		CString strProductID;
		CString strStepID;
		CString strBatchID;
		CString strProd_Type;
		CString strProd_Kind;
		CString strPPID;
		CString strFlowID;
		CString strPanel_Size;
		int nPanel_Size[2];
		int nThickness;
		int nComp_Count;
		int nPanel_State;
		CString	strReading_Flag;		    
		CString	strIns_Flag;				    
		CString	strPanel_Position;      
		CString	strJudgement;			      
		CString strCode;				        
		CString	strFlow_History;
		short nFlow_History[28];
		CString	strCount1;				      
		CString	strCount2;				      
		CString	strGrade;
		short nGrade[8];
		CString	strMulti_Use;		        
		CString	strGlassDataBitSignal; 
		short nGlassDataBitSignal[4];
		CString	strPair_H_PanelID;	    
		CString	strPair_E_PanelID;		  
		CString	strPair_ProductID;		  
		CString	strPair_Grade;
		short nPair_Grade[8];
		CString	strFlow_Group;
		short nFlow_Group[10];
		CString	strDBR_Recipe;
		CString strReferData;
	};
}