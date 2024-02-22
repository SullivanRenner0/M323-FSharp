module Aufgabe_1

let GradZuFahrenheit (grad:float) = grad * 1.8 + 32.0

let FahrenheitZuGrad (fahrenheit:float) = (fahrenheit - 32.0) / 1.8

let BerechneNote (punkte:float) (max:float) = punkte / max * 5.0 + 1.0

let Pythagoras (a: float) (b: float) = sqrt (a**2 + b**2)