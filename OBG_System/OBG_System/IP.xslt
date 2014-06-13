<?xml version='1.0'?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <HTML>
      <BODY>
        <TABLE cellspacing="3" cellpadding="8">
          <TR>
            <TD class="heading">
              <B>Ip</B>
            </TD>
            <TD class="heading">
              <B>Status</B>
            </TD>
            <TD class="heading">
              <B>CountryCode</B>
            </TD>
            <TD class="heading">
              <B>CountryName</B>
            </TD>
            <TD class="heading">
              <B>RegionCode</B>
            </TD>
            <TD class="heading">
              <B>RegionName</B>
            </TD>
            <TD class="heading">
              <B>City</B>
            </TD>
            <TD class="heading">
              <B>ZipPostalCode</B>
            </TD>
            <TD class="heading">
              <B>Latitude</B>
            </TD>
            <TD class="heading">
              <B>Longitude</B>
            </TD>
          </TR>
          <xsl:for-each select="Locations/Location">
            <TR bgcolor="#C1DAD7">
              <TD width="5%" valign="top">
                <xsl:value-of select="Ip"/>
              </TD>
              <TD width="5%" valign="top">
                <xsl:value-of select="Status"/>
              </TD>
              <TD width="10%" valign="top">
                <xsl:value-of select="CountryCode"/>
              </TD>
              <TD width="10%" valign="top">
                <xsl:value-of select="CountryName"/>
              </TD>
              <TD width="10%" valign="top">
                <xsl:value-of select="RegionCode"/>
              </TD>
              <TD width="10%" valign="top">
                <xsl:value-of select="RegionName"/>
              </TD>
              <TD width="10%" valign="top">
                <xsl:value-of select="City"/>
              </TD>
              <TD width="10%" valign="top">
                <xsl:value-of select="ZipPostalCode"/>
              </TD>
              <TD width="10%" valign="top">
                <xsl:value-of select="Latitude"/>
              </TD>
              <TD width="10%" valign="top">
                <xsl:value-of select="Longitude"/>
              </TD>
            </TR>
          </xsl:for-each>
        </TABLE>
      </BODY>
    </HTML>
  </xsl:template>
</xsl:stylesheet>
