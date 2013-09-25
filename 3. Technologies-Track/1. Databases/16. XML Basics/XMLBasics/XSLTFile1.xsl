<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1>My library</h1>
        <table bgcolor="#E0E0E0" cellspacing="1">
          <tr bgcolor="#EEEEEE">
            <td>
              <b>Name</b>
            </td>
            <td>
              <b>Sex</b>
            </td>
            <td>
              <b>Birthday</b>
            </td>
            <td>
              <b>Phone</b>
            </td>
            <td>
              <b>Email</b>
            </td>
            <td>
              <b>Course</b>
            </td>
            <td>
              <b>Soecialty</b>
            </td>
            <td>
              <b>Faculty Number</b>
            </td>
            <td>
              <b>Enrollment</b>
            </td>
            <td>
              <b>Endorsements</b>
            </td>
            <td>
              <b>Listexams</b>
            </td>
          </tr>
          <xsl:for-each select="/students/student">
            <tr bgcolor="white">
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="sex"/>
              </td>
              <td>
                <xsl:value-of select="birthday"/>
              </td>
              <td>
                <xsl:value-of select="phone"/>
              </td>
              <td>
                <xsl:value-of select="email"/>
              </td>
              <td>
                <xsl:value-of select="course"/>
              </td>
              <td>
                <xsl:value-of select="specialty"/>
              </td>
              <td>
                <xsl:value-of select="facnumber"/>
              </td>
              <td>
                <xsl:for-each select="enrollment">
                  <p>
                    Date:
                    <xsl:value-of select="date"/>
                  </p>
                  <p>
                    Score:
                    <xsl:value-of select="score"/>
                  </p>
                </xsl:for-each>
              </td>
              <td>
                <xsl:for-each select="endorsements/teacher">
                  <p>
                    Name:
                    <xsl:value-of select="name"/>
                  </p>
                </xsl:for-each>
              </td>
              <td>
                <xsl:for-each select="listexams/exam">
                  <p>
                    Name:
                    <xsl:value-of select="name"/>
                  </p>
                  <p>
                    Score:
                    <xsl:value-of select="score"/>
                  </p>
                  <p>
                    Tutor:
                    <xsl:value-of select="tutor"/>
                  </p>
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>