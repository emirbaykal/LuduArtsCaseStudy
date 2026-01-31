# LLM Kullanım Dokümantasyonu

> Bu dosyayı case boyunca kullandığınız LLM (ChatGPT, Claude, Copilot vb.) etkileşimlerini belgelemek için kullanın.
> Dürüst ve detaylı dokümantasyon beklenmektedir.

## Özet

| Bilgi | Değer |
|-------|-------|
| Toplam prompt sayısı | 3-4 |
| Kullanılan araçlar | ChatGPT |
| En çok yardım alınan konular | [Interaction System Mimarisi] |
| Tahmini LLM ile kazanılan süre | 1-2 saat |

---

**Not:**
```
[Aslinda surekli kullandim fakat buyuk sorulardansa ufak ufak sordugum seylerde cok oldu. #region kullaniminin dogrusu ne diye bilgimi test ettigim kisimlarda oldu. Az gibi gozukuyor fakat ufak ufak aktif kullandim. Ilk prompt bana ana sistemi cikardiktan sonra cok fazla ihtiyac duymadim.]
```


## Prompt 1: [Konu Başlığı]

**Araç:** [ChatGPT-4]
**Tarih/Saat:** 2026-01-30 16:00

**Prompt:**
```
[Seninle bir Interaction System mimarisi oturtmak istiyorum. “Player“ ve “Item” arasi baglilik en az seviyede olsun istiyorum. Bana kod verme sadece fikir konusmak istiyorum.]
```

**Alınan Cevap (Özet):**
```
[[Ozet olarak bana Interactionda neler olacagini sordu. -Cevap olarak Start, End, Hold, Interact fonksiyonlari olmasini dusundugumu soyledim. - Input -> Player -> Item -> IInteractable -> Trigger fonksiyonlar seklinde bir mimari cizdi.]
]
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım (değişiklik yapmadan)
- [x] Adapte ettim (değişiklikler yaparak)
- [ ] Reddettim (kullanmadım)

**Açıklama:**
> [Aslinda kafamdakileri gorsele dokmek icin sordugum bir promptdu. Cikardigi sablon uzerinden guncellemeler yaptim.
> Eğer reddettiyseniz, neden uygun bulmadığınızı belirtin.]

**Yapılan Değişiklikler (adapte ettiyseniz):**
> [Hold kismini coroutine ile yapmami onerdi bana o kismi coroutine kullanmak istemedigim icin degistirdim. ]


---

## Prompt 2: [Konu Başlığı]

**Araç:** [ChatGPT-4 / Claude / GitHub Copilot]
**Tarih/Saat:** 2026-01-30 18:00

**Prompt:**
```
[New input sistemin avantajlari nelerdir. Hold icin kullanmam daha mi mantikli?]
```

**Alınan Cevap (Özet):**
```
[
[Event-based (started/performed/canceled)
Hold, tap, double tap, slow tap, multi tap gibi davranışları Input System kendi başına yönetir.
Kendi Coroutine veya timer’ını yazmana gerek kalmaz (eğer obje bazlı süre istemiyorsan).
Basit etkileşimler hızlıca event olarak alınır.
]
]
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım
- [x] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [[Hold icin new input systemi kullanmak istiyordum o yuzden biraz detaylariyla ilgili konustum. Action contextinden nelere ulasabildigimi sordum ona gore input actionlari tetikledim.]
]

---

## Prompt 3: ...

[Diğer promptlar için aynı formatı kullanın]

---

## Genel Değerlendirme

### LLM'in En Çok Yardımcı Olduğu Alanlar
1. [Alan 1]
2. [Alan 2]
3. [Alan 3]

### LLM'in Yetersiz Kaldığı Alanlar
1. [Alan 1 - neden yetersiz kaldığı]
2. [Alan 2]

### LLM Kullanımı Hakkında Düşüncelerim
> [Bu case boyunca LLM kullanarak neler öğrendiniz?
> LLM'siz ne kadar sürede bitirebilirdiniz?
> Gelecekte LLM'i nasıl daha etkili kullanabilirsiniz?]

---

## Notlar

- Her önemli LLM etkileşimini kaydedin
- Copy-paste değil, anlayarak kullandığınızı gösterin
- LLM'in hatalı cevap verdiği durumları da belirtin
- Dürüst olun - LLM kullanımı teşvik edilmektedir

---

*Bu şablon Ludu Arts Unity Intern Case için hazırlanmıştır.*
