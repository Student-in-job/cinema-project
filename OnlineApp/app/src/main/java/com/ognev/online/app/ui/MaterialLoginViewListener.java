package com.ognev.online.app.ui;

import android.support.design.widget.TextInputLayout;

/**
 * Created by shem on 1/15/16.
 */
public interface MaterialLoginViewListener {
    void onRegister(TextInputLayout registerFirstName, TextInputLayout registerLastName, TextInputLayout registerUser, TextInputLayout registerPass, TextInputLayout registerPassRep);

    void onLogin(TextInputLayout loginUser, TextInputLayout loginPass);
}
