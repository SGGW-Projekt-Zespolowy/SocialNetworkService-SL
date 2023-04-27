using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum Degree
    {
        student, // student medycyny - np. student Jan Kowalski
        lek, // lekarz medycyny - np. lek. Jan Kowalski
        lekDent, // lekarz dentysta - np. lek. dent. Jan Kowalski
        spec, // lekarz specjalista - np. lek. spec. Jan Kowalski
        Dr, // Doktor nauk medycznych - np. Dr n. med. Jan Kowalski
        DrHab, // Doktor Hablitowany nauk medycznych - np. Dr hab. n. med. Jan Kowalski
        Prof, // Profesor doktor habilitowany nauk medycznych - np. Prof. dr hab. n. med. Jan Kowalski
        MD, // Medical Doctor - odpowiednik zwykłego lekarza po angielsku - np. Jan Kowalski, MD
        MDPhd, // Medical Doctor Philosophy Doctor - odpowiednik doktora nauk medycznych - np. Jan Kowalski, MD PhD
    }

    public enum MedicalSpecialization
    {
        alergologia, // alergologia
        anestezjologia, // anestezjologia i intensywna terapia
        angiologia, // angiologia
        audiologiaFoniatria, // audiologia i foniatria
        balneologiaIMedycynaFizykalna // balneologia i medycyna fizykalna

    }
}
