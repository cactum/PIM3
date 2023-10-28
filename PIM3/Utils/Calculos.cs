namespace PIM3.Utils
{
    public class Calculos
    {
        public static double SalarioBruto(double horas, double valor)
        {
            return horas * valor;
        }

        public static double IR(double SalarioBruto)
        {
            double alíquota = 0, ir = 0;

            if (SalarioBruto >= 1903.99 && SalarioBruto <= 2826.65)
            {
                alíquota = SalarioBruto * 0.075;
                ir = alíquota - 142.8;
            }
            else if (SalarioBruto >= 2826.66 && SalarioBruto <= 3751.05)
            {
                alíquota = SalarioBruto * 0.15;
                ir = alíquota - 354.8;
            }
            else if (SalarioBruto >= 3751.06 && SalarioBruto <= 4664.68)
            {
                alíquota = SalarioBruto * 0.225;
                ir = alíquota - 636.13;
            }
            else if (SalarioBruto > 4664.68)
            {
                alíquota = SalarioBruto * 0.275;
                ir = alíquota - 869.36;
            }
            else
            {
                ir = 0;
            }

            return ir;
        }

        public static double INSS(double valorBruto)
        {
            double inss = 0;
            if (valorBruto <= 1693.72)
            {
                inss = valorBruto * 0.08;
            }
            else if (valorBruto >= 1693.73 && valorBruto <= 2822.90)
            {
                inss = valorBruto * 0.09;
            }
            else if (valorBruto >= 2822.91 && valorBruto <= 5645.8)
            {
                inss = valorBruto * 0.11;
            }
            else if (valorBruto >= 5645.81)
            {
                inss = 621.03;
            }
            else
            {
                inss = 0;
            }

            return inss;
        }

        public static double FGTS(double SalarioBruto)
        {
            return SalarioBruto * 0.08;
        }

        public static double SalarioLíquido(double SalarioBruto, double ir, double inss)
        {
            return SalarioBruto - ir - inss;
        }


    }
}
