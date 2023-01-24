#include "StdAfx.h"
#include "MsgCassetteInfoCommand.h"
#include "../XMLParser.h"

using namespace Message;

CMsgCassetteInfoCommand::CMsgCassetteInfoCommand(void)
{
	m_nMessageType = 1;
	m_nMessageCommand = 15;

	nPortNo = 0;
	strProcessID = "";
	strProductID = "";
	strStepID = "";
	strBatchID = "";
	strProd_Type = "";
	strProd_Kind = "";
	strPPID = "";
	strFlowID = "";
	strPanel_Size = "";
	nThickness = 0;
	nComp_Count = 0;
	nPanel_State = 0;
	strReading_Flag = "";		    
	strIns_Flag = "";				    
	strPanel_Position = "";      
	strJudgement = "";			      
	strCode = "";				        
	strFlow_History = "";
	memset(nFlow_History, 0x00, sizeof(nFlow_History));
	strCount1 = "";				      
	strCount2 = "";				      
	strGrade = "";				        
	strMulti_Use = "";		        
	strGlassDataBitSignal = "";   
	strPair_H_PanelID = "";	    
	strPair_E_PanelID = "";		  
	strPair_ProductID = "";		  
	strPair_Grade = "";			    
	strFlow_Group = "";			    
	strDBR_Recipe = "";
	strReferData= "";
}

CMsgCassetteInfoCommand::~CMsgCassetteInfoCommand(void)
{
}

bool CMsgCassetteInfoCommand::ParseMsg(const CString& strXML) 
{ 
	CString strBuf;
	CString strInfo;
	char szBuf[20];
	int i=0;
	int j=0;

	strInfo = CXMLParser::GetElement(strXML, _T("INFO"));

	strBuf = CXMLParser::GetText(strInfo, _T("PORT"));
	nPortNo = atoi(strBuf);

	strProcessID = CXMLParser::GetText(strInfo, _T("PROCESSID"));
	
	strProductID = CXMLParser::GetText(strInfo, _T("PRODUCTID"));

	strStepID = CXMLParser::GetText(strInfo, _T("STEPID"));
	
	strBatchID = CXMLParser::GetText(strInfo, _T("BATCHID"));

	strProd_Type = CXMLParser::GetText(strInfo, _T("PROD_TYPE"));

	strProd_Kind = CXMLParser::GetText(strInfo, _T("PROD_KIND"));

	strPPID = CXMLParser::GetText(strInfo, _T("PPID"));

	strFlowID = CXMLParser::GetText(strInfo, _T("FLOWID"));
	
	strPanel_Size = CXMLParser::GetText(strInfo, _T("PANEL_SIZE"));

	for(i=0; i<2; i++)
	{
		AfxExtractSubString(strBuf, strPanel_Size, i, ' ');
		nPanel_Size[i] = atoi(strBuf);
	}

	strBuf = CXMLParser::GetText(strInfo, _T("THICKNESS"));
	nThickness = atoi(strBuf);

	strBuf = CXMLParser::GetText(strInfo, _T("COMP_COUNT"));
	nComp_Count = atoi(strBuf);

	strBuf = CXMLParser::GetText(strInfo, _T("PANEL_STATE"));
	nPanel_State = atoi(strBuf);

	strReading_Flag = CXMLParser::GetText(strInfo, _T("READING_FLAG"));

	strIns_Flag = CXMLParser::GetText(strInfo, _T("INS_FLAG"));

	strPanel_Position = CXMLParser::GetText(strInfo, _T("PANEL_POSITION"));

	strJudgement = CXMLParser::GetText(strInfo, _T("JUDGEMENT"));

	strCode = CXMLParser::GetText(strInfo, _T("CODE"));

	strFlow_History = CXMLParser::GetText(strInfo, _T("FLOW_HISTORY"));
	for(i=0; i<28; i++)
	{
		AfxExtractSubString(strBuf, strFlow_History, i, ' ');
		nFlow_History[i] = atoi(strBuf);
	}

	strCount1 = CXMLParser::GetText(strInfo, _T("COUNT1"));

	strCount2 = CXMLParser::GetText(strInfo, _T("COUNT2"));

	strGrade = CXMLParser::GetText(strInfo, _T("GRADE"));
	//2진수 10진수로 끊어 읽어 오기
	j=0;
	for(i=0; i<64; i+=8)
	{
	strBuf = strGrade.Mid(i,8);
	memset(szBuf,0x00,sizeof(szBuf));
	strcpy(szBuf, strBuf.operator LPCTSTR());
	CUtil::ABPLCBinSwap(szBuf, strlen(szBuf));
	nGrade[j] = strtol(szBuf,NULL,2);
	j++;
	}
	/*for(i=0; i<64; i+=8)
	{
		strBuf = strGrade.Mid(i,8);
		nGrade[j] = strtol(strBuf,NULL,2);
		j++;
	}*/

	strMulti_Use = CXMLParser::GetText(strInfo, _T("MULTI_USE"));

	strGlassDataBitSignal = CXMLParser::GetText(strInfo, _T("GLASS_DATA"));
	//2진수 10진수로 끊어 읽어 오기
	j=0;
	for(i=0; i<32; i+=8)
	{
		strBuf = strGlassDataBitSignal.Mid(i,8);
		memset(szBuf,0x00,sizeof(szBuf));
		strcpy(szBuf, strBuf.operator LPCTSTR());
		CUtil::ABPLCBinSwap(szBuf, strlen(szBuf));
		nGlassDataBitSignal[j] = strtol(szBuf,NULL,2);
		j++;
	}
	//j=0;
	//for(i=0; i<32; i+=8)
	//{
	//	strBuf = strGlassDataBitSignal.Mid(i,8);
	//	nGlassDataBitSignal[j] = strtol(strBuf,NULL,2);
	//	j++;
	//}

	strPair_H_PanelID = CXMLParser::GetText(strInfo, _T("PAIR_H_PANELID"));

	strPair_E_PanelID  = CXMLParser::GetText(strInfo, _T("PAIR_E_PANELID"));	

	strPair_ProductID  = CXMLParser::GetText(strInfo, _T("PAIR_PRODUCTID"));

	strPair_Grade = CXMLParser::GetText(strInfo, _T("PAIR_GRADE"));
	//2진수 10진수로 끊어 읽어 오기
	j=0;
	for(i=0; i<64; i+=8)
	{
		strBuf = strPair_Grade.Mid(i,8);
		memset(szBuf,0x00,sizeof(szBuf));
		strcpy(szBuf, strBuf.operator LPCTSTR());
		CUtil::ABPLCBinSwap(szBuf, strlen(szBuf));
		nPair_Grade[j] = strtol(szBuf,NULL,2);
		j++;
	}	
	//j=0;
	//for(i=0; i<64; i+=8)
	//{
	//	strBuf = strPair_Grade.Mid(i,8);
	//	nPair_Grade[j] = strtol(strBuf,NULL,2);
	//	j++;
	//}

	strFlow_Group = CXMLParser::GetText(strInfo, _T("FLOW_GROUP"));
	for(i=0; i<10; i++)
	{
		AfxExtractSubString(strBuf, strFlow_Group, i, ' ');
		nFlow_Group[i] = atoi(strBuf);
	}
	strDBR_Recipe = CXMLParser::GetText(strInfo, _T("DBR_RECIPE"));
	strReferData = CXMLParser::GetText(strInfo, _T("REFER"));		    	 	

	return true; 
}