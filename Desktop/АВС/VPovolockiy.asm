format PE console
include 'win32a.inc'
entry start

section 'data' data readable writeable
Enter_size db 'Enter size:',13,10,0
Enter_elements db 'Enter elements:',13,10,0
Result db 'Result:',0
print_int db ' %d',0
first_array dd 0
first_array_size dd 0
second_array dd 0
second_array_size dd 0
get_int db '%d',0

section 'text' code executable readable
start:
        call get_array_size
        call alloc_arrays
        call get_first_array
        call get_second_array
        call print_result
        call show
        ret
get_array_size:
        cinvoke printf,Enter_size
        cinvoke scanf,get_int,first_array_size
        ret
alloc_arrays:
        mov eax,[first_array_size]
        add eax,eax
        add eax,eax
        cinvoke malloc,eax
        mov [first_array],eax
        mov eax,[first_array_size]
        add eax,eax
        add eax,eax
        cinvoke malloc,eax
        mov [second_array],eax
        ret
get_first_array:
        cinvoke printf,Enter_elements
        mov eax,[first_array]
        mov ecx,[first_array_size]
        .m1:
        push eax
        push ecx
        cinvoke scanf,get_int,eax
        pop ecx
        pop eax
        add eax,4
        loop .m1
        ret
get_second_array:
        mov eax,[first_array]
        mov ecx,[first_array_size]
        mov edx,0
        .m2:
        add edx,[eax]
        add eax,4
        loop .m2
        mov eax,edx
        mov edx,0
        mov ecx,[first_array_size]
        div ecx
        mov edx,eax
        mov eax,[first_array]
        mov ebx,[second_array]
        mov esi,0
        .m3:
        mov edi,[eax]
        cmp edi,edx
        jbe .skip
        mov [ebx],edi
        add ebx,4
        inc esi
        .skip:
        add eax,4
        loop .m3
        mov [second_array_size],esi
        ret
print_result:
        cinvoke printf,Result
        mov edx,[second_array]
        mov ecx,[second_array_size]
        cmp ecx,0
        je .skip
        .m4:
        push edx
        push ecx
        cinvoke printf,print_int,[edx]
        pop ecx
        pop edx
        add edx,4
        loop .m4
        .skip:
        ret
show:
        cinvoke scanf,get_int,first_array_size
        ret
section 'imp' import readable
library msvcrt,'msvcrt.dll'
import msvcrt,\
       scanf,'scanf',\
       printf,'printf',\
       free,'free',\
       malloc,'malloc'


