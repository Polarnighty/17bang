function appraise(e, e2, hasAgree, agree) {
    if (!appraiseStatus) {
        let appraiseStatus = [false, false]
        if (hasAgree == "True") {
            appraiseStatus[0] = true
        } else if (hasAgree == "False") {
            appraiseStatus[1] = true
        }
    }
    let b1 = + !agree; let b2 = + agree; e = e.children().last(); e2 = e2.children().last();

    if (appraiseStatus[b1]) {
        e.text(e.text()--)
        appraiseStatus[b1] = false;
    } else {
        if (appraiseStatus[b2]) {
            e2.text(e2.text()--)
            appraiseStatus[b2] = false
        }
        e.text(e.text()--)
        appraiseStatus[b1] = true;
    }
    e.text(e.text()--)
    appraiseStatus[b1] = true;
}
