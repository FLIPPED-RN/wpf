﻿namespace lab2_nazarov.Modul;

public class Fraction : IPair
{
    private int numerator;
    private int denominator;
    
    //числитель
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }
    
    //знаменатель
    public int Denominator
    {
        get { return denominator; }
        set { denominator = value; }
    }

    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
    }

    //приведение к общему знаменателю
    public static int NOZ(int del0, int del1)
    {
        if (del1 % del0 == 0)
            return del1;
        int temp = 0;
        for (int i = 0;; i++)
        {
            temp = del1 * i;
            if (temp % del0 == 0)
            {
                break;
            }
        }

        return temp;
    }

    //сложение 
    public static Fraction operator +(Fraction A, Fraction B)
    {
        Fraction fraction = new Fraction(0, NOZ(A.Denominator, B.Denominator));
        fraction.numerator = fraction.denominator / A.Denominator * A.Numerator;
        fraction.numerator += fraction.denominator / B.Denominator * B.Numerator;
        return fraction;
    }
    
    //вычитание
    public static Fraction operator -(Fraction A, Fraction B)
    {
        Fraction fraction = new Fraction(0, NOZ(A.Denominator, B.Denominator));
        fraction.numerator = fraction.denominator / A.Denominator * A.Numerator;
        fraction.numerator -= fraction.denominator / B.Denominator * B.Numerator;
        return fraction;
    }
    
    //умножение
    public static Fraction operator *(Fraction A, Fraction B)
    {
        Fraction fraction = new Fraction(A.numerator * B.numerator, A.denominator * B.denominator);
        return fraction;
    }
    
    public static Fraction operator *(Fraction A, int B)
    {
        Fraction fraction = new Fraction(A.numerator * B, A.denominator * B);
        return fraction;
    }
    
    //деление
    public static Fraction operator /(Fraction A, Fraction B)
    {
        Fraction fraction = new Fraction(A.numerator * B.denominator, A.denominator * B.numerator);
        return fraction;
    }
    
    public static Fraction operator /(Fraction A, int B)
    {
        Fraction fraction = new Fraction(A.numerator, A.denominator * B);
        return fraction;
    }

    
    //сокращение дроби
    public void Reduce()
    {
        this.Numerator = this.Numerator > 0 ? this.Numerator : -this.Numerator;
        this.Denominator = this.Denominator > 0 ? this.Denominator : -this.Denominator;

        int maxval = Numerator > Denominator ? Numerator : Denominator;
        for (int i = maxval; i >= 2; maxval--)
        {
            if (Numerator % maxval == 0)
            {
                this.Numerator /= maxval;
                this.Denominator /= maxval;
                break;
            }
        }
    }

    //перевод в десятичную дробь
    public double ToDouble()
    {
        if (denominator != 0)
        {
            return numerator / denominator;
        }
        else
        {
            throw new InvalidOperationException("Знаменатель не должен быть равен нулю!");
        }
    }
    
    public override string ToString()
    {
        return $"{numerator}, {denominator}";
    }
}