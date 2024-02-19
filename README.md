# LogPadeCoefGeneration

Padé approximation coefficients generation for log function.  
![logpade_result_44](figures/logpade_result_44.svg)

## Definition

The function to be approximated is  defined as follows:  
![define](figures/define.svg)

Namely,  
![f_form](figures/f_form.svg)

If both the numerator and denominator are 4 terms, then:  
![terms44](figures/terms44.svg)  
![terms44_accuracy](figures/terms44_accuracy.svg)  

## Precision
The number of terms in the Padé approximation and their relative accuracy as *x*=1 are as follows:  
Each additional 1 term to the numerator denominator, improves the decimal 1.531 digits, or 5.086 bits.  
![logpade_error_x1](figures/logpade_error_x1.svg)

The *x* and relative accuracy are as follows:  
![logpade_error_terms](figures/logpade_error_terms.svg)

## Coefficients
The computation time for the coefficients is O(*n*<sup>4</sup>).  
[results](results)

## See Also
[PadeApproximation](https://github.com/tk-yoshimura/PadeApproximation)