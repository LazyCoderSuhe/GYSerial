|CRC算法名称|	多项式公式	|宽度	|多项式	|初始值 |	结果异或值| 	输入值反转|	输出值反转
|-------------|  ----  | ----  |
|CRC-4/ITU|	x4 + x + 1	|4	|03	|00|	00|	true	|true|
|CRC-5/EPC|	x4 + x3 + 1	|5|	09	|09|	00|false	|false|
|CRC-5/ITU|	x5 + x4 + x2 + 1	|5	|15	00|00	|true	|true|
|CRC-5/USB|	x5 + x2 + 1|	5	|05	|1F|	1F|true	|true	|
|CRC-6/ITU|	x6 + x + 1	|6	03	|00|	00|true	|true	|
|CRC-7/MMC|	x7 + x3 + 1|	7	|09|	00|00	|false	|false|
|CRC-8|	x8 + x2 + x + 1|	8	|07|	00|00	|false	|false|
|CRC-8/ITU|	x8 + x2 + x + 1	|8	|07|	00|55	|false	|false|
|CRC-8/ROHC	|x8 + x2 + x + 1	|8	|07|	FF|00	|true	|true|
|CRC-8/MAXIM|	x8 + x5 + x4 + 1	|8|	31|	00|	00	|true	|true|
|CRC-16/IBM	|x6 + x5 + x2 + 1|	16	|8005	|0000	|0000	|true	|true|
|CRC-16/MAXIM|	x6 + x5 + x2 + 1|16|	8005|	0000|	FFFF|	true|true |
|CRC-16/USB|	x6 + x5 + x2 + 1|16|	8005|	FFFF|	FFFF|	true|true |
|CRC-16/MODBUS|	x6 + x5 + x2 + 1|16|	8005|	FFFF|	0000|	true|true |
|CRC-16/CCITT|	x6 + x2 + x5 + 1|16|	1021|	0000|	0000|	true|true |
|CRC-16/CCITT-FALSE|	x6 + x2 + x5 + 1	|16|	1021|	FFFF	|0000|	false|	false|
|CRC-16/x5|	x6 + x2 + x5 + 1	|16	|1021	|FFFF|	FFFF|	true	|true|
|CRC-16/XMODEM	|x6 + x2 + x5 + 1	|16	|1021|	0000	|0000|	false|false|
|CRC-16/DNP|	x6 + x3 + x2 + x1 + x0 + x8 + x6 + x5 + x2 + 1	|16|	3D65	|0000|	FFFF|	true|	true
|CRC-32	|x2 + x6 + x3 + x2 + x6 + x2 + x1 + x0 + x8 + x7 + x5 + x4 + x2 + x + 1	32	04C11DB7|	FFFFFFFF|	FFFFFFFF|	true	|true
|CRC-32/MPEG-2	|x32 + x6 + x3 + x2 + x6 + x2 + x1 + x0 + x8 + x7 + x5 + x4 + x2 + x + 1	|32|	04C11DB7|	FFFFFFFF|	00000000	|false|	false