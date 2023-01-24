#pragma once

#include "IPLC.h"

namespace PLC
{
	class CPLCSigEventObject
	{
	public:
		CPLCSigEventObject(void);
		virtual ~CPLCSigEventObject(void);
public:
		void SetPLCNo(int nPLCNo)						{m_nPLCNo = nPLCNo;}
		void SetPortNo(int nPortNo)						{m_nPortNo = nPortNo;}
		void SetData(char *pData, int &nIndex);
		int GetPortNo()								{return m_nPortNo;}
private:
		int m_nPortNo;
		int m_nPLCNo;

		//int m_nEventID;
		//CString m_strPortID;
		//int m_nPortState;
		//int m_nPortType;
		//CString m_strPortMode;
		//int m_nSortType;
		//int m_nCSTDemand;
		//CString m_strCSTID;
		//CString m_strCSTType;
		//CString m_strMat_Stif;
		//CString m_strCur_Stif;
		//int m_nBatch_Order;
		//short m_nByWho;
		//short m_nReply;
		PortInfoItem m_strPortInfoItem;
	};
}
