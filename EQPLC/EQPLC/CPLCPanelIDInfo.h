#pragma once

#include "IPLC.h"
#include "ABConfig.h"

namespace PLC
{
	class CPLCPanelIDInfo : public IPLC
	{
	public:
		struct PanelIDInfo
		{
			int nPort;
			char szHPanelID[12];
			char szUniqueID[4];
			int nUniqueID[4];
		};

	public:
		CPLCPanelIDInfo(void);
		virtual ~CPLCPanelIDInfo(void);

	public:
		virtual void GetData(int nPortNo, char * szOutData);
		void SetPanelIDInfo(PanelIDInfo &stPanelIDInfo);

	private:
		void MakePanelIDInfo(int nPortNo, int &nIndex);

	private:
		char m_szData[80];

		PanelIDInfo m_stPanelIDInfo1;
		PanelIDInfo m_stPanelIDInfo2;
		PanelIDInfo m_stPanelIDInfo3;
		PanelIDInfo m_stPanelIDInfo4;
	};
}