# Crear el Proyecto

```
dotnet new console --framework net5.0 -n PrintMultiples
```
# Descargar Nugets y restaurar el proyecto

```
dotnet restore .\PrintPrimes.csproj
```

# Compilar y Construir el ejecutable

```
dotnet build .\PrintPrimes.csproj
```

# Ejecutar el Proyecto

```
dotnet run .\PrintPrimes.csproj
```
# Notas
## PrintPrimes (3.3)
- No tiene Errores Ni Warnings (0.5)      = 0.5
- No tiene Codigo Innecesario  (0.5)      = 0.0 > El Try/Catch no es Necesario
- Funciona y Cumple con el Objetivo (1.5) = 1.4 => No deberia imprimir la Ultima coma
- El codigo Es Entendible (1.0)           = 0.5 => El codigo es parcialmente entendible
- Cumple con el Codigo Limpio (1.5)       = 0.9
  Los Nombres de las variables y Funciones: (0.1/ cada una)
  - Revelan la intencion, es decir se sabe que hacen o que almacenan? = X
  - Los Nombres son claros o son confusos?                            = OK
  - Son Pronunciables                                                 = OK
  - Son buscables (Numero Magicos o No hay Constantes)?               = X => Porque se valida el menor a 2
  - tiene notaciones innecesarias IntCodigo, strData) ?               = OK
  - Usan Sustantivos para Clases y Verbos para Metodos?               = OK
  - Una sola palabra por concepto?                                    = OK
  - No usan combinaciones o juegos de palabras?                       = OK
  - No tiene contexto adicional o superfluo?                          = OK
  - Usan Datos del dominio, del negocio, problema o solucion ?        = OK
  - Cumplen con el Estandar de Pascal y Camel Case?                   = OK
  Las Funciones                                                         
  - Son pequeñas y su logica esta bien separada?                      = X
  - Las Funciones hacen una sola cosa?                                = X
  - Tieen Logica de Retorno directo y correcto o hay If para retornar = X
  - No Existen Multiples If anidados o SI hay instrucciones Switch    = X

## Print Multiples (4.2)
- No tiene Errores Ni Warnings (0.5)      = 0.5
- No tiene Codigo Innecesario  (0.5)      = 0.0 => No tieen sentido el primer If
- Funciona y Cumple con el Objetivo (1.5) = 1.5
- El codigo Es Entendible (1.0)           = 0.5
- Cumple con el Codigo Limpio (1.5)       = 0.7
  Los Nombres de las variables y Funciones: (0.1/ cada una)
  - Revelan la intencion, es decir se sabe que hacen o que almacenan? = X
  - Los Nombres son claros o son confusos?                            = X
  - Son Pronunciables                                                 = OK
  - Son buscables (Numero Magicos o No hay Constantes)?               = X
  - tiene notaciones innecesarias IntCodigo, strData) ?               = OK
  - Usan Sustantivos para Clases y Verbos para Metodos?               = OK
  - Una sola palabra por concepto?                                    = OK
  - No usan combinaciones o juegos de palabras?                       = OK
  - No tiene contexto adicional o superfluo?                          = OK
  - Usan Datos del dominio, del negocio, problema o solucion ?        = OK
  - Cumplen con el Estandar de Pascal y Camel Case?                   = X
  Las Funciones                                                         
  - Son pequeñas y su logica esta bien separada?                      = X
  - Las Funciones hacen una sola cosa?                                = X
  - Tieen Logica de Retorno directo y correcto o hay If para retornar = X
  - No Existen Multiples If anidados o SI hay instrucciones Switch    = X

## Debugging (0.0)
- No tiene Errores Ni Warnings (0.5)      = 
- No tiene Codigo Innecesario  (0.5)      = 
- Funciona y Cumple con el Objetivo (1.5) = 
- El codigo Es Entendible (1.0)           = 
- Cumple con el Codigo Limpio (1.5)       = 
  Los Nombres de las variables y Funciones: (0.1/ cada una)
  - Revelan la intencion, es decir se sabe que hacen o que almacenan? = OK
  - Los Nombres son claros o son confusos?                            = OK
  - Son Pronunciables                                                 = OK
  - Son buscables (Numero Magicos o No hay Constantes)?               = OK
  - tiene notaciones innecesarias IntCodigo, strData) ?               = OK
  - Usan Sustantivos para Clases y Verbos para Metodos?               = OK
  - Una sola palabra por concepto?                                    = OK
  - No usan combinaciones o juegos de palabras?                       = OK
  - No tiene contexto adicional o superfluo?                          = OK
  - Usan Datos del dominio, del negocio, problema o solucion ?        = OK
  - Cumplen con el Estandar de Pascal y Camel Case?                   = OK
  Las Funciones                                                         
  - Son pequeñas y su logica esta bien separada?                      = OK
  - Las Funciones hacen una sola cosa?                                = OK
  - Tieen Logica de Retorno directo y correcto o hay If para retornar = OK
  - No Existen Multiples If anidados o SI hay instrucciones Switch    = OK
