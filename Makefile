SOURCES = \
	facebook.cs

all: monotouch-facebook.dll

monotouch-facebook.dll: $(SOURCES)
	/Developer/MonoTouch/usr/bin/btouch -out=monotouch-facebook.dll facebook.cs
