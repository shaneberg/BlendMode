@ECHO ON

SET FXCCMD="C:\Program Files (x86)\Microsoft DirectX SDK (June 2010)\Utilities\Bin\x64\FXC.EXE"
SET RELATIVE_PS_HLSL=..\PixelShaders\
SET RELATIVE_PS_OUT=..\CompiledShaders\

PUSHD %~dp0%RELATIVE_PS_HLSL%

FOR /R %%G in (*.HLSL) DO %FXCCMD% %%G /E main /T:ps_2_0 /Fo %RELATIVE_PS_OUT%%%G.ps