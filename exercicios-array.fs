variable size
0 size !

variable buf 1000 cells allot

: get-number ( -- n )
    pad 20 accept pad swap
    s>number? if
        drop
    else 
        2drop 0
    then
;

: push ( a -- )
    size @ cells buf + !
    1 size +!
;

: pop ( -- a )
    -1 size +!
    size @ cells buf + @
;

: get ( i -- a )
    cells buf + @
;

: set ( a i -- )
    cells buf + !
;

: print-array ( -- )
    size @ 0 ?do
        i get .
    loop
;

: array-sum ( -- sum )
    0
    size @ 0 ?do
        i get +
    loop
;

: array-max ( -- max )
    0 get
    size @ 1 ?do
        i get max
    loop
;

: array-min ( -- min )
    0 get
    size @ 1 ?do
        i get min
    loop
;

: array-average ( F: -- avg )
    array-sum s>f
    size @ s>f
    f/
;

: read-array ( -- )
    0 size !
    begin
        get-number dup 0<>
    while
        push
    repeat
    drop
;
