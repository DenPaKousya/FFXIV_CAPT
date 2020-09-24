Module MOD_FIELD_MARKER

    Public Function FUNC_GET_CONTENT_NAME(ByVal INT_ID_CONTENT_01 As Integer, ByVal INT_ID_CONTENT_02 As Integer) As String
        Dim STR_RET As String
        Select Case INT_ID_CONTENT_01
            Case &H30
                STR_RET = FUNC_GET_NAME_CONTENT_30(INT_ID_CONTENT_02)
            Case &H31
                STR_RET = FUNC_GET_NAME_CONTENT_31(INT_ID_CONTENT_02)
            Case &H33
                STR_RET = FUNC_GET_NAME_CONTENT_33(INT_ID_CONTENT_02)
            Case Else
                STR_RET = ""
        End Select

        Return STR_RET
    End Function

    Public Function FUNC_GET_NAME_CONTENT_30(ByVal INT_ID_CONTENT As Integer) As String
        Dim STR_RET As String
        STR_RET = ""
        Select Case INT_ID_CONTENT
            Case &H12
                STR_RET = "極白虎征魂戦"
            Case &H13
                STR_RET = "白虎征魂戦"
            Case &H27
                STR_RET = "極神龍討滅戦"
            Case &H36
                STR_RET = "ラクシュミ討滅戦"
            Case &H39
                STR_RET = "極ラクシュミ討滅戦"
            Case &HEA
                STR_RET = "極リオレウス狩猟戦"
            Case &HEB
                STR_RET = "リオレウス狩猟戦"
            Case Else
                STR_RET = ""
        End Select

        Return STR_RET
    End Function

    Public Function FUNC_GET_NAME_CONTENT_31(ByVal INT_ID_CONTENT As Integer) As String
        Dim STR_RET As String
        STR_RET = ""
        Select Case INT_ID_CONTENT
            Case &H2
                STR_RET = "坑道に現れた妖異ブソを討て！"
            Case &H3
                STR_RET = "汚染源モルボルを討て！"
            Case &H6
                STR_RET = "三つ巴の巨人族を制し、遺物を守れ！"
            Case &H7
                STR_RET = "不気味な陣形を組む妖異をせん滅せよ！"
            Case &H8
                STR_RET = "タイタン討滅戦"
            Case &H9
                STR_RET = "イフリート討滅戦"
            Case &HA
                STR_RET = "真イフリート討滅戦"
            Case &HB
                STR_RET = "ガルーダ討滅戦"
            Case &HC
                STR_RET = "真ガルーダ討滅戦"
            Case &HD
                STR_RET = "真タイタン討滅戦"
            Case &HE
                STR_RET = "極イフリート討滅戦"
            Case &HF
                STR_RET = "リットアティン強襲戦"
            Case &H11
                STR_RET = "幻龍残骸 黙約の塔"
            Case &H1A
                STR_RET = "彷徨う死霊を討て！"
            Case &H1B
                STR_RET = "集団戦訓練をくぐり抜けろ！"
            Case &H20
                STR_RET = "怪鳥巨塔 シリウス大灯台"
            Case &H21
                STR_RET = "最終決戦 魔導城プラエトリウム"
            Case &H22
                STR_RET = "妖異屋敷 ハウケタ御用邸 (Hard)"
            Case &H23
                STR_RET = "騒乱坑道 カッパーベル銅山 (Hard)"
            Case &H24
                STR_RET = "剣闘領域 ハラタリ修練所 (Hard)"
            Case &H25
                STR_RET = "盟友支援 ブレイフロクスの野営地 (Hard)"
            Case &H26
                STR_RET = "財宝伝説 ハルブレーカー・アイル"
            Case &H27
                STR_RET = "腐敗遺跡 古アムダプール市街"
            Case &H28
                STR_RET = "城塞奪回 ストーンヴィジル (Hard)"
            Case &H29
                STR_RET = "惨劇霊殿 タムタラの墓所 (Hard)"
            Case &H2A
                STR_RET = "氷結潜窟 スノークローク大氷壁"
            Case &H2B
                STR_RET = "遺跡救援 カルン埋没寺院 (Hard)"
            Case &H2C
                STR_RET = "邪念排撃 古城アムダプール (Hard)"
            Case &H2D
                STR_RET = "逆襲要害 サスタシャ浸食洞 (Hard)"
            Case &H2F
                STR_RET = "武装聖域 ワンダラーパレス (Hard)"
            Case &H30
                STR_RET = "監獄廃墟 トトラクの千獄"
            Case &H32
                STR_RET = "封鎖坑道 カッパーベル銅山"
            Case &H33
                STR_RET = "地下霊殿 タムタラの墓所"
            Case &H34
                STR_RET = "霧中行軍 オーラムヴェイル"
            Case &H35
                STR_RET = "天然要塞サスタシャ浸食洞"
            Case &H36
                STR_RET = "魔獣領域 ハラタリ修練所"
            Case &H37
                STR_RET = "名門屋敷 ハウケタ御用邸"
            Case &H38
                STR_RET = "遺跡探索 カルン埋没寺院"
            Case &H39
                STR_RET = "奪還支援 ブレイフロクスの野営地"
            Case &H3A
                STR_RET = "城塞攻略 ストーンヴィジル"
            Case &H3B
                STR_RET = "旅神聖域 ワンダラーパレス"
            Case &H3C
                STR_RET = "掃討作戦 ゼーメル要塞"
            Case &H3D
                STR_RET = "流砂迷宮 カッターズクライ"
            Case &H3E
                STR_RET = "外郭攻略 カストルム・メリディアヌム"
            Case &H3F
                STR_RET = "邪教排撃 古城アムダプール"
            Case &H60
                STR_RET = "アマジナ杯闘技会決勝戦	"
            Case &H61
                STR_RET = "極シヴァ討滅戦"
            Case &H63
                STR_RET = "闘神オーディン討滅戦"
            Case &H64
                STR_RET = "真ギルガメッシュ討滅戦"
            Case &H65
                STR_RET = "アシエン・ナプリアレス討伐戦"
            Case &H66
                STR_RET = "極ラーヴァナ討滅戦"
            Case &H67
                STR_RET = "真ラーヴァナ討滅戦"
            Case &H68
                STR_RET = "極ビスマルク討滅戦"
            Case &H69
                STR_RET = "真ビスマルク討滅戦"
            Case &H6A
                STR_RET = "蒼天幻想 ナイツ・オブ・ラウンド討滅戦"
            Case &H6B
                STR_RET = "ナイツ・オブ・ラウンド討滅戦"
            Case &H70
                STR_RET = "極ガルーダ討滅戦"
            Case &H71
                STR_RET = "極タイタン討滅戦"
            Case &H72
                STR_RET = "極王モグル・モグXII世討滅戦"
            Case &H73
                STR_RET = "善王モグル・モグXII世討滅戦"
            Case &H75
                STR_RET = "究極幻想 アルテマウェポン破壊作戦"
            Case &H78
                STR_RET = "極リヴァイアサン討滅戦"
            Case &H79
                STR_RET = "真リヴァイアサン討滅戦"
            Case &H7A
                STR_RET = "ハイドラ討伐戦"
            Case &H7B
                STR_RET = "ドルムキマイラ討伐戦"
            Case &H7C
                STR_RET = "真ラムウ討滅戦"
            Case &H7D
                STR_RET = "ギルガメッシュ討伐戦"
            Case &H7E
                STR_RET = "真シヴァ討滅戦"
            Case &H7F
                STR_RET = "極ラムウ討滅戦"
            Case &H86
                STR_RET = "女神ソフィア討滅戦"
            Case &H89
                STR_RET = "極女神ソフィア討滅戦"
            Case &H98
                STR_RET = "ニーズヘッグ征竜戦"
            Case &H9B
                STR_RET = "極ニーズヘッグ征竜戦"
            Case &HB6
                STR_RET = "極魔神セフィロト討滅戦"
            Case &HB7
                STR_RET = "魔神セフィロト討滅戦"
            Case &HEE
                STR_RET = "鬼神ズルワーン討滅戦"
            Case &HD1
                STR_RET = "極鬼神ズルワーン討滅戦"
            Case &HC2
                STR_RET = "スサノオ討滅戦"
            Case &HC5
                STR_RET = "極スサノオ討滅戦"
            Case &HDE
                STR_RET = "神龍討滅戦"
            Case Else
                STR_RET = ""
        End Select

        Return STR_RET
    End Function

    Public Function FUNC_GET_NAME_CONTENT_33(ByVal INT_ID_CONTENT As Integer) As String
        Dim STR_RET As String
        STR_RET = ""
        Select Case INT_ID_CONTENT
            Case &H28
                STR_RET = "ツクヨミ討滅戦"
            Case &H2B
                STR_RET = "極ツクヨミ討滅戦"
            Case &H4C
                STR_RET = "青龍征魂戦"
            Case &H4F
                STR_RET = "極青龍征魂戦"
            Case &H62
                STR_RET = "真ヨウジンボウ討滅戦"
            Case &H64
                STR_RET = "極朱雀征魂戦"
            Case &H65
                STR_RET = "朱雀征魂戦"
            Case &HE1
                STR_RET = "希望の園エデン零式：共鳴編2"
            Case &HE6
                STR_RET = "希望の園エデン零式：共鳴編3"
            Case &HE8
                STR_RET = "希望の園エデン零式：共鳴編4"
            Case &HFD
                STR_RET = "希望の園エデン零式：共鳴編1"
            Case &HFF
                STR_RET = "極ルビーウェポン破壊作戦"
            Case Else
                STR_RET = ""
        End Select

        Return STR_RET
    End Function
End Module
