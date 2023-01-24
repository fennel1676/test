// Util.cpp: implementation of the CUtil class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "Util.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////
HANDLE	CUtil::hConsole = NULL;
BOOL	CUtil::bLogFileDateFlag = TRUE; 
BOOL	CUtil::bCSVFileDateFlag = FALSE;
BOOL	CUtil::bFile = FALSE;
BOOL	CUtil::bLine = FALSE;

void CUtil::WriteDataFile(const char *pszDataFileName, const char *pszData, int nDataCnt)
{
	/*FILE	*fp = NULL;
	CString	strFileName = "";
	CTime Time = CTime::GetCurrentTime();
	
	if(NULL == pszDataFileName)
	{
		strFileName.Format("%04d%02d%02d.dat", Time.GetYear(), Time.GetMonth(), Time.GetDay());
	}
	else
	{
		if(CUtil::bLogFileDateFlag)
			strFileName.Format("%s_%04d%02d%02d.dat", pszDataFileName, Time.GetYear(), Time.GetMonth(), Time.GetDay());
		else
			strFileName.Format("%04d%02d%02d_%s.dat", Time.GetYear(), Time.GetMonth(), Time.GetDay(), pszDataFileName);
	}
	
	fopen_s(&fp, strFileName.operator LPCTSTR(), "a+t");
	
	if(NULL == fp)
		return;
	
	fwrite(pszData, 1, nDataCnt, fp);
		
	fclose(fp);*/
}

void CUtil::WriteLogFile(const char *pszLogFileName, const char *sfmt, ...)
{
	//FILE	*fp = NULL;
	///*try
	//{*/
	//	CString	strFileName = "", strBuf = "";
	//	CTime Time = CTime::GetCurrentTime();

	//	if(NULL == pszLogFileName)
	//	{
	//		strFileName.Format("%04d%02d%02d%02d.Log", Time.GetYear(), Time.GetMonth(), Time.GetDay(), Time.GetTime());
	//	}
	//	else
	//	{
	//		if(CUtil::bLogFileDateFlag)
	//			strFileName.Format("%s_%04d%02d%02d%02d.Log", pszLogFileName, Time.GetYear(), Time.GetMonth(), Time.GetDay(), Time.GetTime());
	//		else
	//			strFileName.Format("%04d%02d%02d%02d_%s.Log", Time.GetYear(), Time.GetMonth(), Time.GetDay(), Time.GetTime(), pszLogFileName);
	//	}
	//	
	//	fopen_s(&fp, strFileName.operator LPCTSTR(), "a+t");

	//	if(NULL == fp)
	//		return;

	//	char szTemp[1024*10];
	//	memset(szTemp,0x00,sizeof(szTemp));

	//	va_list va;
	//	va_start(va, sfmt);
	//	vsprintf(szTemp, sfmt, va);

	//	strBuf.Format("[%02d:%02d:%02d]", Time.GetHour(), Time.GetMinute(), Time.GetSecond());
	//	if(CUtil::bFile)
	//	{
	//		strBuf += " ";
	//		strBuf += __FILE__;
	//	}
	//	strBuf += " ";
	//	strBuf += szTemp;
	//	strBuf += "\n";
	//	fprintf(fp, strBuf.operator LPCTSTR());
	//	
	//	if(NULL != CUtil::hConsole)
	//	{
	//		DWORD	dw;
	//		WriteFile(hConsole, strBuf.operator LPCTSTR(), strBuf.GetLength(), &dw,NULL);
	//	}

	//	fclose(fp);
	//	fp = NULL;
	//}
	//catch (CException* e)
	//{
	//	e;
	//	if(NULL != fp)
	//		fclose(fp);
	//}

}

void CUtil::WriteLogFile(CString &strLogFileName, const char *sfmt, ...)
{
	FILE	*fp = NULL;
	try
	{
		CString	strFileName = "", strBuf = "";
		CTime Time = CTime::GetCurrentTime();

		if(strLogFileName.IsEmpty())
		{
			strFileName.Format("%04d%02d%02d%02d.Log", Time.GetYear(), Time.GetMonth(), Time.GetDay(), Time.GetHour());
		}
		else
		{
			if(CUtil::bLogFileDateFlag)
				strFileName.Format("%s_%04d%02d%02d%02d.Log", strLogFileName.operator LPCTSTR(), Time.GetYear(), Time.GetMonth(), Time.GetDay(), Time.GetHour());
			else
				strFileName.Format("%04d%02d%02d%02d_%s.Log", Time.GetYear(), Time.GetMonth(), Time.GetDay(), Time.GetHour(), strLogFileName.operator LPCTSTR());
		}

		fopen_s(&fp, strFileName.operator LPCTSTR(), "a+t");

		if(NULL == fp)
			return;

		char szTemp[1024*10];
		memset(szTemp,0x00,sizeof(szTemp));

		va_list va;
		va_start(va, sfmt);
		vsprintf(szTemp, sfmt, va);

		strBuf.Format("[%02d:%02d:%02d]", Time.GetHour(), Time.GetMinute(), Time.GetSecond());
		if(CUtil::bFile)
		{
			strBuf += " ";
			strBuf += __FILE__;
		}
		strBuf += " ";
		strBuf += szTemp;
		strBuf += "\n";
		fprintf(fp, strBuf.operator LPCTSTR());

		if(NULL != CUtil::hConsole)
		{
			DWORD	dw;
			WriteFile(hConsole, strBuf.operator LPCTSTR(), strBuf.GetLength(), &dw,NULL);
		}

		fclose(fp);
		fp = NULL;
	}
	catch (CException* e)
	{
		e;
		if(NULL != fp)
			fclose(fp);
	}

}

void CUtil::WriteCSVFile(const char *pszCSVFileName, const char *sfmt, ...)
{
	/*FILE	*fp = NULL;
	CString	strFileName = "", strBuf = "";
	CTime Time = CTime::GetCurrentTime();
	
	if(NULL == pszCSVFileName)
	{
		strFileName.Format("%04d%02d%02d.csv", Time.GetYear(), Time.GetMonth(), Time.GetDay());
	}
	else
	{
		if(CUtil::bCSVFileDateFlag)
			strFileName.Format("%s_%04d%02d%02d.csv", pszCSVFileName, Time.GetYear(), Time.GetMonth(), Time.GetDay());
		else
			strFileName.Format("%04d%02d%02d_%s.csv", Time.GetYear(), Time.GetMonth(), Time.GetDay(), pszCSVFileName);
	}
	
	fopen_s(&fp, strFileName.operator LPCTSTR(), "a+t");

	if(NULL == fp)
		return;
	
	char szTemp[1024*10];
	memset(szTemp,0x00,sizeof(szTemp));
	
	va_list va;
	va_start(va, sfmt);
	vsprintf(szTemp, sfmt, va);
	
	strBuf.Format("[%02d:%02d:%02d]", Time.GetHour(), Time.GetMinute(), Time.GetSecond());
	if(CUtil::bFile)
	{
		strBuf += " ";
		strBuf += __FILE__;
	}
	strBuf += " ";
	strBuf += szTemp;
	strBuf += "\n";
	fprintf(fp, strBuf.operator LPCTSTR());
	
	if(NULL != CUtil::hConsole)
	{
		DWORD	dw;
		WriteFile(hConsole, strBuf.operator LPCTSTR(), strBuf.GetLength(), &dw,NULL);
	}
	
	fclose(fp);*/
}

void CUtil::WriteCSVFile(CString &strCSVFileName, const char *sfmt, ...)
{
	/*FILE	*fp = NULL;
	CString	strFileName = "", strBuf = "";
	CTime Time = CTime::GetCurrentTime();
	
	if(strCSVFileName.IsEmpty())
	{
		strFileName.Format("%04d%02d%02d.csv", Time.GetYear(), Time.GetMonth(), Time.GetDay());
	}
	else
	{
		if(CUtil::bCSVFileDateFlag)
			strFileName.Format("%s_%04d%02d%02d.csv", strCSVFileName.operator LPCTSTR(), Time.GetYear(), Time.GetMonth(), Time.GetDay());
		else
			strFileName.Format("%04d%02d%02d_%s.csv", Time.GetYear(), Time.GetMonth(), Time.GetDay(), strCSVFileName.operator LPCTSTR());
	}
	
	fopen_s(&fp, strFileName.operator LPCTSTR(), "a+t");

	if(NULL == fp)
		return;
	
	char szTemp[1024*10];
	memset(szTemp,0x00,sizeof(szTemp));
	
	va_list va;
	va_start(va, sfmt);
	vsprintf(szTemp, sfmt, va);
	
	strBuf.Format("[%02d:%02d:%02d]", Time.GetHour(), Time.GetMinute(), Time.GetSecond());
	if(CUtil::bFile)
	{
		strBuf += " ";
		strBuf += __FILE__;
	}
	strBuf += " ";
	strBuf += szTemp;
	strBuf += "\n";
	fprintf(fp, strBuf.operator LPCTSTR());
	
	if(NULL != CUtil::hConsole)
	{
		DWORD	dw;
		WriteFile(hConsole, strBuf.operator LPCTSTR(), strBuf.GetLength(), &dw,NULL);
	}
	
	fclose(fp);*/
}

void CUtil::DeleteLogFile(CString strLogPath, int nValue)
{
	CString strFileName = "";
	CTime CurrentTime = CTime::GetCurrentTime();
	CTime ResultTime;

	for(int i=0; i < 5; i++)
	{
		ResultTime = CurrentTime - CTimeSpan(nValue+i, 0, 0, 0);
		strFileName.Format(_T("%04d%02d%02d%02d"),ResultTime.GetYear(), ResultTime.GetMonth(), ResultTime.GetDay(), ResultTime.GetHour());
		strFileName =strLogPath + "_" + strFileName + ".Log";
		DeleteFile(strFileName);
	}
}

void CUtil::ShowConsole(BOOL bShow)
{
	if(!bShow)
	{
		FreeConsole();
		hConsole = NULL;
	}
	else
	{
		if(NULL == hConsole)
		{
			if(AllocConsole())
				CUtil::hConsole = ::GetStdHandle(STD_OUTPUT_HANDLE);
		}		
	}
}

void CUtil::IPC_Send(const char *szCaption, void *pData, int nSize)
{
	HWND hFind = ::FindWindow(NULL, szCaption);
	COPYDATASTRUCT	cbs;
	
	cbs.dwData = 0;
	cbs.cbData = nSize;
	cbs.lpData = (void *)pData;
	
	::SendMessage(hFind, WM_COPYDATA, NULL, (LPARAM)&cbs);	
}

long CUtil::Str2Hex(const char *szHex, int nCnt)
{
	long	nResult = 0;
	byte	cBuf;

	for(int i = 0; i < nCnt; i++)
	{
		cBuf = szHex[i];

		if('0' <= cBuf && cBuf <= '9')
		{	
			nResult <<= 4;
			cBuf -= '0';
			nResult += cBuf;
		}
		else if('A' <= cBuf && cBuf <= 'F')
		{
			nResult <<= 4;
			cBuf -= 'A';
			cBuf += 10;
			nResult += cBuf;
		}
		else if('a' <= cBuf && cBuf <= 'f')
		{
			nResult <<= 4;
			cBuf -= 'a';
			cBuf += 10;
			nResult += cBuf;
		}
	}

	if(8 == nCnt)
	{
		long	nBuf = nResult;
		char	*pBuf = (char *)&nBuf, *pResult = (char *)&nResult;

		memcpy(&pResult[2], pBuf, 2);
		memcpy(pResult, &pBuf[2], 2);
	}

	return nResult;
}

CString CUtil::GetFullPathName(CString strPath)
{
	if(strPath.IsEmpty())
		return CString(_T(""));
	
	TCHAR szDir[_MAX_DIR];
	if(!::GetFullPathName(strPath.operator LPCTSTR(),_MAX_DIR,szDir,NULL))
		return CString(_T(""));
	return CString(szDir);
}

bool CUtil::IsExistDirectory(CString strFullPath)
{
	bool bRet = false;
	if(!strFullPath.IsEmpty())
	{
		TCHAR buff[_MAX_PATH];
		::GetCurrentDirectory(_MAX_PATH, buff);
		
		if(::SetCurrentDirectory(strFullPath.operator LPCTSTR()))
			bRet = true;
		
		::SetCurrentDirectory(buff);
	}
	return bRet;
}

int CUtil::DeleteFilesInSameDir(CString strFullDirectoryPath, CString strFind, int nDaysAgo)
{
	if(strFind.IsEmpty() || 0 == nDaysAgo)
		return 0;
	
	if(!IsExistDirectory(strFullDirectoryPath))
		return 0;
	
	int nCount = 0;
	TCHAR szCurrDir[_MAX_DIR];
	::GetCurrentDirectory(_MAX_DIR, szCurrDir);
	::SetCurrentDirectory(strFullDirectoryPath.operator LPCTSTR());
	
	//FILETIME Calculate
	SYSTEMTIME stDelete;
	::GetSystemTime(&stDelete);
	
	FILETIME ftDelete;
	if(!::SystemTimeToFileTime(&stDelete, &ftDelete))
		return 0;
	
	INT64 i64;
	i64=(((INT64)ftDelete.dwHighDateTime) << 32) + ftDelete.dwLowDateTime;
	i64 = i64 - (864000000000 * nDaysAgo);
	ftDelete.dwHighDateTime = (DWORD)(i64 >> 32);
	ftDelete.dwLowDateTime = (DWORD)(i64 & 0xffffffff);
	
	//Find Files
	HANDLE hFind;
	WIN32_FIND_DATA FindData; 
	
	
	hFind = ::FindFirstFile(__T(strFind.operator LPCTSTR()), &FindData);
	BOOL bOK = (INVALID_HANDLE_VALUE != hFind);	
	while(bOK)
	{
		if(!(FindData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY))
		{
			if(::CompareFileTime(&FindData.ftCreationTime , &ftDelete) == -1)
			{
				if(::DeleteFile(FindData.cFileName))
					++nCount;
			}
			else if(::CompareFileTime(&FindData.ftLastAccessTime , &ftDelete) == -1)
			{
				if(::DeleteFile(FindData.cFileName))
					++nCount;
			}
			else if(::CompareFileTime(&FindData.ftLastWriteTime , &ftDelete) == -1)
			{
				if(::DeleteFile(FindData.cFileName))
					++nCount;
			}
		}
		bOK = ::FindNextFile(hFind, &FindData);
	}
	if(INVALID_HANDLE_VALUE != hFind)
		::FindClose(hFind);
	
	::SetCurrentDirectory(szCurrDir);
	return nCount;
}

BOOL CUtil::TickCheck(DWORD dPeriode, DWORD dLastTime)
{
	DWORD	dDef, dCurTime;
	dCurTime = (DWORD)GetCurrentTime();
	if(dLastTime > dCurTime)
		dDef = ((DWORD)0xffffffffL - dLastTime) + dCurTime;
	else
		dDef = dCurTime - dLastTime;
	return (dDef >= dPeriode);
}

void CUtil::ShowFile(BOOL bShow)
{
	bFile = bShow;
}

void CUtil::ShowLine(BOOL bShow)
{
	bLine = bShow;
}

BOOL CUtil::ABPLCStrSwap(char *szOutStr, int nLength)
{
	//if(0 != (nLength % 2))		return FALSE;
	//if(0 == (nLength % 4))
	//{
	//	int nCnt = nLength / 4;

	//	char cBuf;
	//	for(int i = 0; i < nCnt; i++)
	//	{
	//		cBuf = szOutStr[i * 4];
	//		szOutStr[i * 4] = szOutStr[i * 4 + 3];
	//		szOutStr[i * 4 + 3] = cBuf;
	//		cBuf = szOutStr[i * 4 + 1];
	//		szOutStr[i * 4 + 1] = szOutStr[i * 4 + 2];
	//		szOutStr[i * 4 + 2] = cBuf;
	//	}
	//}
	//else if(0 == (nLength % 2))
	//{
	//	int nCnt = nLength / 2;

	//	char cBuf;
	//	for(int i = 0; i < nCnt; i++)
	//	{
	//		cBuf = szOutStr[i * 2];
	//		szOutStr[i * 2] = szOutStr[i * 2 + 1];
	//		szOutStr[i * 2 + 1] = cBuf;
	//	}
	//}
	return TRUE;
}

BOOL CUtil::ABPLCBinSwap(char *szOutStr, int nLength)
{
	if(0 != (nLength % 2))		return FALSE;

	int nCnt = nLength / 2;

	char cBuf;
	for(int i = 0; i < nCnt; i++)
	{
		cBuf = szOutStr[i];
		szOutStr[i] = szOutStr[nLength - i - 1];
		szOutStr[nLength - i - 1] = cBuf;
	}
	return TRUE;
}
