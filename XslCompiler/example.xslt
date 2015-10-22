<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes" omit-xml-declaration="yes"/>			
			<xsl:template match="/products/product">
				<tr>
					<td><b><xsl:value-of select="name"/></b></td>
					<td><b>£<xsl:value-of select="price"/></b></td>
					<td><b><xsl:value-of select="category"/></b></td>
				</tr>
			</xsl:template>
</xsl:stylesheet>
