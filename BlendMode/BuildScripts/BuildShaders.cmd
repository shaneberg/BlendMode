@ECHO ON

SET FXCCMD="C:\Program Files (x86)\Microsoft DirectX SDK (June 2010)\Utilities\Bin\x64\FXC.EXE"
SET RELATIVE_PS_HLSL=..\PixelShaders\
SET RELATIVE_PS_OUT=..\CompiledShaders\
SET FILEPATH=%~dp0

PUSHD %~dp0%RELATIVE_PS_HLSL%

MKDIR -P %RELATIVE_PS_OUT%
REM ERASE %RELATIVE_PS_OUT%*.PS

FOR /R %%G in (*.HLSL) DO %FXCCMD% %%G /E main /T:ps_2_0 /Cc /Ni /Fo %RELATIVE_PS_OUT%\%%~nG.ps

POPD