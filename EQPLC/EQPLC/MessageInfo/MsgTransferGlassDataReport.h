#pragma once
#include "../MessageInfo.h"

namespace Message
{
class CMsgTransferGlassDataReport : public IMessageInfo
{
public:
	CMsgTransferGlassDataReport(void);
	virtual ~CMsgTransferGlassDataReport(void);

public:
	virtual const CString GetMsg();
	virtual bool ParseMsg(const CString& strXML) { return false; }

public:
	CString strUnitName;
	CString strExist;                
	CString	strEventID;			        
	CString	strHPanelID;			      
	CString	strEPanelID;			      
	CString	strProcessID;			      
	CString strProductID;			      
	CString strStepID;							
	CString strBatchID;							
	CString strProdType;						
	CString strProdKind;						
	CString strPPID;								
	CString strFlowID;							
	CString strPanelSize;					
	CString strThickness;						
	CString strCompCount;					
	CString	strPanelState;		      
	CString	strReadingFlag;		    
	CString	strInsFlag;				    
	CString	strPanelPosition;      
	CString	strJudgement;			      
	CString	strCode;				        
	CString	strFlowHistory;	      
	CString	strUniqueID;			      
	CString	strCount1;				      
	CString	strCount2;				      
	CString	strGrade;				        
	CString	strMutiUse;		        
	CString	strGlassDataBitSignal;   
	CString	strPairHPanelID;	    
	CString	strPairEPanelID;		  
	CString	strPairProductID;		  
	CString	strPairGrade;			    
	CString	strFlowGroup;			    
	CString	strDBRRecipe;			    
	CString	strReferData;			      
	CString	strContactPointState1;
	CString	strContactPointState2;
	CString strFromEQNo;
	CString strToEQNo;
	CString strSlotID;

	/////////////////////////////////////////////////
	//CString strRefuseCode;
	//CString strHSSignalBit;
};
}