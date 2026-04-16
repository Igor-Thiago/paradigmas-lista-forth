
: get-number ( -- n )
    pad 20 accept pad swap  ( lê até 20 caracteres e deixa addr n na pilha )
    s>number? if            ( converte string para número de dupla precisão e uma flag )
        drop                ( remove a parte de dupla precisão, deixando apenas a parte baixa na pilha )
    else 
        2drop 0             ( limpa a pilha em caso de falha e retorna 0 )
    then 
;

create buf 1000 cells allot
variable size
0 size !

: push ( a -- )
    size @ cells buf + !
    1 size +!
;

: pop ( -- a )
    -1 size +!
    size @ cells buf + @
;

: get ( i -- n )
    cells buf + @
;

: set ( a i -- )
    cells buf + !
;

: read-array ( -- )
    begin
        get-number dup
    while
        push
    repeat
    drop
;

: print-array ( -- )
    size @ 0 do
        i get .
    loop
;

: add-array ( -- sum )
    0
    size @ 0 do
        i get +
    loop
;

: max-array ( -- max )
    size @ 0= if
        0 exit
    then

    0 get
    size @ 1 do
        i get max
    loop
;

: min-array ( -- min )
    size @ 0= if
        0 exit
    then

    0 get
    size @ 1 do
        i get min
    loop
;

: average-array ( F: -- avg )
    size @ 0= if
        0e exit
    then

    add-array s>f
    size @ s>f
    f/
;