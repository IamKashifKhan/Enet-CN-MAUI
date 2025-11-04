
export function showHideModal(showModal){
     if (showModal) {
       $("#modalRedeemSuccess").modal("show");
     } else {
       $("#modalRedeemSuccess").modal("hide");
    }
}