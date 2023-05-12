using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum DegreeEnum
    {
        Student, // student medycyny - np. student Jan Kowalski
        Lek, // lekarz medycyny - np. lek. Jan Kowalski
        LekDent, // lekarz dentysta - np. lek. dent. Jan Kowalski
        Spec, // lekarz specjalista - np. lek. spec. Jan Kowalski
        Dr, // Doktor nauk medycznych - np. Dr n. med. Jan Kowalski
        DrHab, // Doktor Hablitowany nauk medycznych - np. Dr hab. n. med. Jan Kowalski
        Prof, // Profesor doktor habilitowany nauk medycznych - np. Prof. dr hab. n. med. Jan Kowalski
        MD, // Medical Doctor - odpowiednik zwykłego lekarza po angielsku - np. Jan Kowalski, MD
        MDPhd, // Medical Doctor Philosophy Doctor - odpowiednik doktora nauk medycznych - np. Jan Kowalski, MD PhD
    }

    public enum MedicalSpecializationEnum
    {
        Alergologia,
        AnestezjologiaIIntensywnaTerapia,
        Angiologia,
        AudiologiaIFoniatria,
        BalneologiaIMedycynaFizykalna,
        ChirurgiaDziecieca,
        ChirurgiaKlatkiPiersiowej,
        ChirurgiaNaczyniowa,
        ChirurgiaOgolna,
        ChirurgiaOnkologiczna,
        ChirurgiaPlastyczna,
        ChirurgiaSzczekowoTwarzowa,
        ChorobyPluc,
        ChorobyPlucDzieci,
        ChorobyWewnetrzne,
        ChorobyZakazne,
        DermatologiaIWenerologia,
        Diabetologia,
        DiagnostykaLaboratoryjna,
        Endokrynologia,
        EndokrynologiaGinekologicznaIRozrodczosc,
        EndokrynologiaIDiabetologiaDziecieca,
        Epidemiologia,
        FarmakologiaKliniczna,
        Gastroenterologia,
        GastroenterologiaDziecieca,
        GenetykaKliniczna,
        Geriatria,
        GinekologiaOnkologiczna,
        Hematologia,
        Hipertensjologia,
        ImmunologiaKliniczna,
        IntensywnaTerapia,
        Kardiochirurgia,
        Kardiologia,
        KardiologiaDziecieca,
        MedycynaLotnicza,
        MedycynaMorskaITropikalna,
        MedycynaNuklearna,
        MedycynaPaliatywna,
        MedycynaPracy,
        MedycynaRatunkowa,
        MedycynaRodzinna,
        MedycynaSadowa,
        MedycynaSportowa,
        MikrobiologiaLekarska,
        Nefrologia,
        NefrologiaDziecieca,
        Neonatologia,
        Neurochirurgia,
        Neurologia,
        NeurologiaDziecieca,
        Neuropatologia,
        Okulistyka,
        OnkologiaIHematologiaDziecieca,
        OnkologiaKliniczna,
        OrtopediaITraumatologiaNarzaduRuchu,
        Otorynolaryngologia,
        OtorynolaryngologiaDziecieca,
        Patomorfologia,
        Pediatria,
        PediatriaMetaboliczna,
        Perinatologia,
        PoloznictwoIGinekologia,
        Psychiatria,
        PsychiatriaDzieciIMlodziezy,
        RadiologiaIDiagnostykaObrazowa,
        RadioterapiaOnkologiczna,
        RehabilitacjaMedyczna,
        Reumatologia,
        Seksuologia,
        ToksykologiaKliniczna,
        TransfuzjologiaKliniczna,
        TransplantologiaKliniczna,
        Urologia,
        UrologiaDziecieca,
        ZdrowiePubliczne
    }

    public enum BadgeEnum
    {

    }

    public enum ReactionTypeEnum
    {
        Like, 
        Dislike
    }
}
