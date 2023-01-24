extern "C" __declspec(dllimport) int _SMPD_ProcessInitial(char *hostIP, char *configFileName, 
													  NewDataCallBackType *pfn1Event, 
													  StatusChangeCallBackType *pfn2Event,
													  char* chSMDFilePath);
extern "C" __declspec(dllimport) void _SMPD_ProcessEnd();
extern "C" __declspec(dllimport) int _SMPD_NodeWrite(int nStrLenth, char *chWriteData, char* chNodeRoot,
														 char* chNodeFirst = NULL, char* chNodeSecond = NULL, 
														 char* chNodeThird = NULL, char* chNodeFourth = NULL );
extern "C" __declspec(dllimport) int  _SMPD_NodeRead(int nReadLength, char* chReadReturn, char* chNodeRoot,
														 char* chNodeFirst = NULL, char* chNodeSecond = NULL, 
														 char* chNodeThird = NULL, char* chNodeFourth = NULL);
/*
*	Module Name			:	nZGetNumberOfAllVariables
*	Parameter			:	����
*	Return				:	Variables ����.
*	Function			:	Tag �� �� ����
*							
*	Create				:	2008.01.21
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdGetNumberOfAllVariables();

/*
*	Module Name			:	n_EtAdGetAllVariableIds
*	Parameter			:	Tag ID
*	Return				:	Variables ����.
*	Function			:	Size��ŭ buff�� ���� ������
*							
*	Create				:	2008.01.21
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdGetAllVariableIds(int *buff, int size);

/*
*	Module Name			:	n_EtAdGetVariableBaseTypeName
*	Parameter			:	Tag ID
*	Return				:	BaseType�� ����(DINT,INT,SINT,BOOL,REAL)
*	Function			:	Varid�� BaseType�� ������
*							
*	Create				:	2008.01.21
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) char *n_EtAdGetVariableBaseTypeName(int variableId);

/*
*	Module Name			:	n_EtAdGetVariableName
*	Parameter			:	Tag ID
*	Return				:	Tag Name
*	Function			:	Varid�� TagName�� ������
*							
*	Create				:	2008.01.21
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) const char *n_EtAdGetVariableName(int variableId);

/*
*	Module Name			:	n_EtAdGetVariableLength
*	Parameter			:	Tag ID
*	Return				:	Var Length
*	Function			:	Varid�� Length�� ������
*							
*	Create				:	2008.01.21
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdGetVariableLength(int variableId);

/*
*	Module Name			:	n_EtAdIsVariableProduced
*	Parameter			:	Tag ID
*	Return				:	Produce�̸� TRUE, �ƴϸ� FALSE
*	Function			:	Produce���� �ƴ��� Ȯ��
*							
*	Create				:	2008.01.21
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) BOOL n_EtAdIsVariableProduced(int variableId);

/*
*	Module Name			:	n_EtAdIsVariableConsumed
*	Parameter			:	Tag ID
*	Return				:	Consume�̸� TRUE, �ƴϸ� FALSE
*	Function			:	Consume���� �ƴ��� Ȯ��
*							
*	Create				:	2008.01.21
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) BOOL n_EtAdIsVariableConsumed(int variableId);

/*
*	Module Name			:	n_EtAdIsVariableOnline
*	Parameter			:	Tag ID
*	Return				:	Consume�� Online�̸� TRUE, �ƴϸ� FALSE
*	Function			:	Consume�� Online ����Ȯ��
*							
*	Create				:	2008.01.21
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) BOOL n_EtAdIsVariableOnline(int variableId);

/*
*	Module Name			:	n_EtAdIsVariableOnline
*	Parameter			:	Tag ID
*	Return				:	Consume�� Online�̸� TRUE, �ƴϸ� FALSE
*	Function			:	Consume�� Online ����Ȯ��
*							
*	Create				:	2008.01.21
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) BOOL n_EtAdIsVariableOnline(int variableId);

/*
*	Module Name			:	n_EtAdGetNumberOfConnections
*	Parameter			:	Tag ID
*	Return				:	Digit : ����� �� ��.
*	Function			:	���� ����� Consume �� ��.
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdGetNumberOfConnections(int nTagID);

/*
*	Module Name			:	n_EtAdTriggerProducingVariable
*	Parameter			:	Tag ID
*	Return				:	Produce�� �ƴϸ� FALSE, Trigged�� ����Ǹ� TRUE
*	Function			:	���� ����� Consume �� ��.
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
//extern "C" __declspec(dllimport) BOOL n_EtAdTriggerProducingVariable(int variableId);

/*
*	Module Name			:	n_EtAdReadVariableDintValue
*	Parameter			:	Tag ID
*	Return				:	Read �� ����
*	Function			:	DINT Type�� Read
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReadVariableDintValue(int variableId, INT32 *pv, int pl);

/*
*	Module Name			:	n_EtAdReadVariableIntValue
*	Parameter			:	Tag ID
*	Return				:	Read �� ����
*	Function			:	INT Type�� Read
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReadVariableIntValue(int variableId, INT16 *pv, int pl);

/*
*	Module Name			:	n_EtAdReadVariableIntValue
*	Parameter			:	Tag ID
*	Return				:	Read �� ����
*	Function			:	SINT Type�� Read
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReadVariableSintValue(int variableId, INT8 *pv, int pl);

/*
*	Module Name			:	n_EtAdReadVariableBoolValue
*	Parameter			:	Tag ID
*	Return				:	Read �� ����
*	Function			:	BOOL Type�� Read
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReadVariableBoolValue(int variableId, BOOL *pv, int pl);

/*
*	Module Name			:	n_EtAdReadVariableRealValue
*	Parameter			:	Tag ID
*	Return				:	Read �� ����
*	Function			:	REAL Type�� Read
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReadVariableRealValue(int variableId, float *pv, int pl);

/*
*	Module Name			:	n_EtAdWriteVariableDintValue
*	Parameter			:	Tag ID
*	Return				:	Write �� ����
*	Function			:	DINT Type�� Write
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdWriteVariableDintValue(int variableId, INT32 *pv, int pl);

/*
*	Module Name			:	n_EtAdWriteVariableIntValue
*	Parameter			:	Tag ID
*	Return				:	Write �� ����
*	Function			:	INT Type�� Write
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdWriteVariableIntValue(int variableId, INT16 *pv, int pl);

/*
*	Module Name			:	n_EtAdWriteVariableSintValue
*	Parameter			:	Tag ID
*	Return				:	Write �� ����
*	Function			:	SINT Type�� Write
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdWriteVariableSintValue(int variableId, INT8 *pv, int pl);

/*
*	Module Name			:	n_EtAdWriteVariableBoolValue
*	Parameter			:	Tag ID
*	Return				:	Write �� ����
*	Function			:	BOOL Type�� Write
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdWriteVariableBoolValue(int variableId, BOOL *pv, int pl);

/*
*	Module Name			:	n_EtAdWriteVariableRealValue
*	Parameter			:	Tag ID
*	Return				:	Write �� ����
*	Function			:	REAL Type�� Write
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdWriteVariableRealValue(int variableId, float *pv, int pl);

/*
*	Module Name			:	n_EtAdSendVariableDintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Send DINT
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendVariableDintValue(char *ioAddress, char *varName, INT32 *pv, int pl);

/*
*	Module Name			:	n_EtAdSendVariableIntValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Send INT
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendVariableIntValue(char *ioAddress, char *varName, INT16 *pv, int pl);

/*
*	Module Name			:	n_EtAdSendVariableSintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Send SINT
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendVariableSintValue(char *ioAddress, char *varName, INT8 *pv, int pl);

/*
*	Module Name			:	n_EtAdSendVariableBoolValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Send BOOL
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendVariableBoolValue(char *ioAddress, char *varName, BOOL *pv, int pl);

/*
*	Module Name			:	n_EtAdSendVariableRealValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Send BOOL
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendVariableRealValue(char *ioAddress, char *varName, float *pv, int pl);

/*
*	Module Name			:	n_EtAdReceiveVariableDintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Receive DINT
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveVariableDintValue(char *ioAddress, char *varName, INT32 *pv, int pl);

/*
*	Module Name			:	n_EtAdReceiveVariableIntValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Receive INT
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveVariableIntValue(char *ioAddress, char *varName, INT16 *pv, int pl);

/*
*	Module Name			:	n_EtAdReceiveVariableSintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Receive SINT
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveVariableSintValue(char *ioAddress, char *varName, INT8 *pv, int pl);

/*
*	Module Name			:	n_EtAdReceiveVariableBoolValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Receive BOOL
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveVariableBoolValue(char *ioAddress, char *varName, BOOL *pv, int pl);

/*
*	Module Name			:	n_EtAdReceiveVariableRealValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	UCMM Receive REAL
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveVariableRealValue(char *ioAddress, char *varName, float *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialDintVariableRead
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start��ġ���� Read(DINT)
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialDintVariableRead(int variableId, int index, INT32 *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialIntVariableRead
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start��ġ���� Read(INT)
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialIntVariableRead(int variableId, int index, INT16 *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialSintVariableRead
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start��ġ���� Read(SINT)
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialSintVariableRead(int variableId, int index, INT8 *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialBoolVariableRead
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start��ġ���� Read(BOOL)
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialBoolVariableRead(int variableId, int index, BOOL *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialRealVariableRead
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start��ġ���� Read(REAL)
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialRealVariableRead(int variableId, int index, float *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialDintVariableWrite
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start��ġ���� Write(DINT)
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialDintVariableWrite(int variableId, int index, INT32 *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialIntVariableWrite
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start��ġ���� Write(INT)
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialIntVariableWrite(int variableId, int index, INT16 *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialSintVariableWrite
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start��ġ���� Write(SINT)
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialSintVariableWrite(int variableId, int index, INT8 *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialBoolVariableWrite
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start��ġ���� Write(BOOL)
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialBoolVariableWrite(int variableId, int index, BOOL *pv, int pl);

/*
*	Module Name			:	n_EtAdPartialRealVariableWrite
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS1 start��ġ���� Write(REAL)
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdPartialRealVariableWrite(int variableId, int index, float *pv, int pl);

/*
*	Module Name			:	n_EtAdOpenClass3Connection
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Connection
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdOpenClass3Connection(char *ioAddress, int rate);

/*
*	Module Name			:	n_EtAdReceiveClass3VariableDintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Receive DINT
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveClass3VariableDintValue(int connectionId, char *srcVarName, int srcVarLen, int destVarId);

/*
*	Module Name			:	n_EtAdReceiveClass3VariableIntValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Receive INT
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveClass3VariableIntValue(int connectionId, char *srcVarName, int srcVarLen, int destVarId);

/*
*	Module Name			:	n_EtAdReceiveClass3VariableSintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Receive SINT
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveClass3VariableSintValue(int connectionId, char *srcVarName, int srcVarLen, int destVarId);

/*
*	Module Name			:	n_EtAdReceiveClass3VariableRealValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Receive REAL
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdReceiveClass3VariableRealValue(int connectionId, char *srcVarName, int srcVarLen, int destVarId);

/*
*	Module Name			:	n_EtAdSendClass3VariableDintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Send DINT
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendClass3VariableDintValue(int connectionId, char *destVarName, int destVarLen, int srcVarId);

/*
*	Module Name			:	n_EtAdSendClass3VariableIntValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Send INT
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendClass3VariableIntValue(int connectionId, char *destVarName, int destVarLen, int srcVarId);

/*
*	Module Name			:	n_EtAdSendClass3VariableSintValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Send SINT
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendClass3VariableSintValue(int connectionId, char *destVarName, int destVarLen, int srcVarId);

/*
*	Module Name			:	n_EtAdSendClass3VariableRealValue
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Send REAL
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) int n_EtAdSendClass3VariableRealValue(int connectionId, char *destVarName, int destVarLen, int srcVarId);

/*
*	Module Name			:	n_EtAdCloseConnection
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 Close
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) BOOL n_EtAdCloseConnection(int connectionId);

/*
*	Module Name			:	n_EtAdGetConnectionIds
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 ����� id���� ����
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) void n_EtAdGetConnectionIds(int maxBufSize, int *buf, int *size);

/*
*	Module Name			:	n_EtAdGetConnectionInfo
*	Parameter			:	Tag ID
*	Return				:	
*	Function			:	CLASS3 ���� ����
*							
*	Create				:	2008.01.18
*	Author				:	������
*	Version				:	1.0
*/
extern "C" __declspec(dllimport) BOOL n_EtAdGetConnectionInfo(int connectionId, ConnectionType *type, int *localVarId, int *transportType, 
															  UINT32 *receiveIPAddr, UINT32 *transmitIPAddr, int *rate, long *uptime);





// �����/�� Ȯ���ʿ�
// extern "C" __declspec(dllimport) int nZReceiveVariable(char *hostIP, char* chSrcTag, char* chDataID);
// extern "C" __declspec(dllimport) int nSendVariable(char *hostIP, char* chSrcTag, char* chDataID);

