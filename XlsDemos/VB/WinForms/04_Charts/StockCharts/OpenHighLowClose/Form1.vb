Imports Microsoft.VisualBasic
Imports System
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

Imports Spire.Xls
Imports Spire.Xls.Charts

Namespace Spire.Xls.Sample
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private WithEvents btnRun As System.Windows.Forms.Button
		Private WithEvents btnAbout As System.Windows.Forms.Button
		Private label1 As System.Windows.Forms.Label
		''' <summary>
		''' Required designer variable.
		''' </summary
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()
			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btnRun = New System.Windows.Forms.Button()
			Me.btnAbout = New System.Windows.Forms.Button()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' btnRun
			' 
			Me.btnRun.Location = New System.Drawing.Point(448, 56)
			Me.btnRun.Name = "btnRun"
			Me.btnRun.Size = New System.Drawing.Size(72, 23)
			Me.btnRun.TabIndex = 2
			Me.btnRun.Text = "Run"
'			Me.btnRun.Click += New System.EventHandler(Me.btnRun_Click);
			' 
			' btnAbout
			' 
			Me.btnAbout.Location = New System.Drawing.Point(528, 56)
			Me.btnAbout.Name = "btnAbout"
			Me.btnAbout.TabIndex = 3
			Me.btnAbout.Text = "Close"
'			Me.btnAbout.Click += New System.EventHandler(Me.btnAbout_Click);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Font = New System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(134)))
			Me.label1.Location = New System.Drawing.Point(16, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(466, 18)
			Me.label1.TabIndex = 4
			Me.label1.Text = "The sample demonstrates how to create stock chart in an excel workbook."
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
			Me.ClientSize = New System.Drawing.Size(616, 94)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.btnAbout)
			Me.Controls.Add(Me.btnRun)
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "Form1"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Chart sample"
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Private Sub btnRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRun.Click
			Dim workbook As Workbook = New Workbook()

			'Initailize worksheet
			workbook.CreateEmptySheets(1)
			Dim sheet As Worksheet = workbook.Worksheets(0)
			sheet.Name = "Chart data"
			sheet.GridLinesVisible = False

			'Writes chart data
			CreateChartData(sheet)
			'Add a new  chart worsheet to workbook
			Dim chart As Chart = sheet.Charts.Add()

			'Set region of chart data
			chart.DataRange = sheet.Range("A1:E8")
			chart.SeriesDataFromRange = False

			'Set position of chart
			chart.LeftColumn = 1
			chart.TopRow = 6
			chart.RightColumn = 11
			chart.BottomRow = 29

			chart.ChartType = ExcelChartType.StockVolumeOpenHighLowClose

			'Chart title
			chart.ChartTitle = "Stock chart"
			chart.ChartTitleArea.IsBold = True
			chart.ChartTitleArea.Size = 12

			chart.PrimaryCategoryAxis.Title = "Stock"
			chart.PrimaryCategoryAxis.Font.IsBold = True
			chart.PrimaryCategoryAxis.TitleArea.IsBold = True

			chart.PrimaryValueAxis.Title = "Price(in Dollars)"
			chart.PrimaryValueAxis.HasMajorGridLines = False
			chart.PrimaryValueAxis.TitleArea.TextRotationAngle = 90
			chart.PrimaryValueAxis.MinValue = 1000
			chart.PrimaryValueAxis.TitleArea.IsBold = True

			Dim cs As Charts.ChartSerie = chart.Series(0)

			chart.Legend.Position = LegendPositionType.Top
			workbook.SaveToFile("Sample.xls")
			ExcelDocViewer(workbook.FileName)
		End Sub

		Private Sub CreateChartData(ByVal sheet As Worksheet)
			Dim RCAddress As String = "A{0}:E{0}"
			'Volume
			sheet.Range("A1").Value = "Volume"
			sheet.Range("A2").NumberValue = 12000
			sheet.Range("A3").NumberValue = 10000
			sheet.Range("A4").NumberValue = 7000
			sheet.Range("A5").NumberValue = 8000
			sheet.Range("A6").NumberValue = 21000
			sheet.Range("A7").NumberValue = 14000
			sheet.Range("A8").NumberValue = 13000

			'Open
            sheet.Range("B1").Value = "Open"
			sheet.Range("B2").NumberValue = 44
			sheet.Range("B3").NumberValue = 43
			sheet.Range("B4").NumberValue = 47
			sheet.Range("B5").NumberValue = 42
			sheet.Range("B6").NumberValue = 49
			sheet.Range("B7").NumberValue = 43
			sheet.Range("B8").NumberValue = 48

			'High
			sheet.Range("C1").Value = "High"
			sheet.Range("C2").NumberValue = 47
			sheet.Range("C3").NumberValue = 49
			sheet.Range("C4").NumberValue = 45
			sheet.Range("C5").NumberValue = 48
			sheet.Range("C6").NumberValue = 51
			sheet.Range("C7").NumberValue = 55
			sheet.Range("C8").NumberValue = 56

			'Low
			sheet.Range("D1").Value = "Low"
			sheet.Range("D2").NumberValue = 38
			sheet.Range("D3").NumberValue = 40
			sheet.Range("D4").NumberValue = 41
			sheet.Range("D5").NumberValue = 40
			sheet.Range("D6").NumberValue = 45
			sheet.Range("D7").NumberValue = 49
			sheet.Range("D8").NumberValue = 50

			'Close
			sheet.Range("E1").Value = "Close"
			sheet.Range("E2").NumberValue = 42
			sheet.Range("E3").NumberValue = 45
			sheet.Range("E4").NumberValue = 44
			sheet.Range("E5").NumberValue = 48
			sheet.Range("E6").NumberValue = 59
			sheet.Range("E7").NumberValue = 53
			sheet.Range("E8").NumberValue = 51

			'Style
			sheet.Range("A1:E1").Style.Font.IsBold = True
			For i As Integer = 2 To 7
				If i Mod 2 = 0 Then
					sheet.Range(String.Format(RCAddress,i)).Style.KnownColor = ExcelColors.LightYellow
				Else
					sheet.Range(String.Format(RCAddress,i)).Style.KnownColor = ExcelColors.LightGreen1
				End If
			Next i

			'Border
			sheet.Range("A1:E8").Style.Borders(BordersLineType.EdgeTop).Color = Color.FromArgb(0, 0, 128)
			sheet.Range("A1:E8").Style.Borders(BordersLineType.EdgeTop).LineStyle = LineStyleType.Thin
			sheet.Range("A1:E8").Style.Borders(BordersLineType.EdgeBottom).Color = Color.FromArgb(0, 0, 128)
			sheet.Range("A1:E8").Style.Borders(BordersLineType.EdgeBottom).LineStyle = LineStyleType.Thin
			sheet.Range("A1:E8").Style.Borders(BordersLineType.EdgeLeft).Color = Color.FromArgb(0, 0, 128)
			sheet.Range("A1:E8").Style.Borders(BordersLineType.EdgeLeft).LineStyle = LineStyleType.Thin
			sheet.Range("A1:E8").Style.Borders(BordersLineType.EdgeRight).Color = Color.FromArgb(0, 0, 128)
			sheet.Range("A1:E8").Style.Borders(BordersLineType.EdgeRight).LineStyle = LineStyleType.Thin

			sheet.Range("B2:E8").Style.NumberFormat = """$""#,##0"
		End Sub

		Private Sub ExcelDocViewer(ByVal fileName As String)
			Try
				System.Diagnostics.Process.Start(fileName)
			Catch
			End Try
		End Sub

		Private Sub btnAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAbout.Click
			Close()
		End Sub


	End Class
End Namespace
