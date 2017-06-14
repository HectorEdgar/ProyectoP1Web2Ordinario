<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
      <html>
        <body>
          <h2>Lista de todas las horas en la semana disponibles</h2>
          <table border="1">
            <tr bgcolor="#9acd32">
              <th>idHorarioGimnasio_Horas</th>
              <th>dia</th>
              <th>idHorario</th>
              <th>idHora</th>
            </tr>
            <xsl:for-each select="horariosGimnasio_Horas/HorarioGimnasio_Horas">
              <tr>
                <td>
                  <xsl:value-of select="idHorarioGimnasio_Horas"/>
                </td>
                <td>
                  <xsl:value-of select="dia"/>
                </td>
                <td>
                  <xsl:value-of select="idHorario"/>
                </td>
                <td>
                  <xsl:value-of select="idHora"/>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
