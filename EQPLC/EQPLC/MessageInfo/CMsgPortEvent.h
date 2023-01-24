#pragma once
#include "../MessageInfo.h"

namespace Message
{
	class CMsgPortEvent : public IMessageInfo
	{
	public:
		CMsgPortEvent(void);
		virtual ~CMsgPortEvent(void);

	public:
		virtual const CString GetMsg();
		virtual bool ParseMsg(const CString& strXML) { return false; }

	public:
		int nPortNum;
		int nEventID;
		CString strPortID;
		int nPortState;
		int nPortType;
		CString strPortMode;
		int nSortType;
		int nCSTDemand;
		CString strCSTID;
		CString strCSTType;
		CString strMat_Stif;
		CString strCur_Stif;
		int nBatch_Order;
		short nByWho;
		short nReply;

	};
}