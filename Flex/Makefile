MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
MONOPROJECT=source/Flex/
BIN=source/Flex/bin/
OBJ=source/Flex/obj
LIB=$(BIN)Release/
EXTERN=extern/
RELEASE=library
MASTER=extern/FLEX-master/
TARGET=FLEX

all: clean prepare assembly

prepare:
	mkdir $(EXTERN)
	curl https://codeload.github.com/Flipboard/FLEX/zip/master -o extern/Flex-iOS.zip
	unzip $(EXTERN)Flex-iOS.zip	-d $(EXTERN)

assembly: 
	xcodebuild -project $(MASTER)$(TARGET).xcodeproj -target $(TARGET) -configuration Release
	$(MONOXBUILD) /p:Configuration=Release $(MONOPROJECT)Flex.csproj
	mkdir $(RELEASE)
	cp $(LIB)Flex.dll $(RELEASE)/

clean: 
	-rm -rf $(LIB) $(OBJ) $(BIN) $(RELEASE) $(EXTERN)