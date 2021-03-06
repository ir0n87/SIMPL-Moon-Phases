using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_DATE_DIFF
{
    public class UserModuleClass_DATE_DIFF : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.DigitalInput CALCOLA;
        Crestron.Logos.SplusObjects.AnalogOutput FASELUNAREOGGI;
        Crestron.Logos.SplusObjects.AnalogOutput FASELUNAREDOMANI;
        Crestron.Logos.SplusObjects.AnalogOutput FASELUNAREDOPODOMANI;
        public override object FunctionMain (  object __obj__ ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusFunctionMainStartCode();
                
                __context__.SourceCodeLine = 22;
                WaitForInitializationComplete ( ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            return __obj__;
            }
            
        private uint CHECK_FOR_LEAPYEARS (  SplusExecutionContext __context__, int STARTYEAR , int ENDYEAR ) 
            { 
            int I = 0;
            int LY = 0;
            int LEAPYEARS = 0;
            
            
            __context__.SourceCodeLine = 31;
            LEAPYEARS = (int) ( 0 ) ; 
            __context__.SourceCodeLine = 34;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( STARTYEAR > ENDYEAR ))  ) ) 
                { 
                __context__.SourceCodeLine = 36;
                I = (int) ( STARTYEAR ) ; 
                __context__.SourceCodeLine = 37;
                STARTYEAR = (int) ( ENDYEAR ) ; 
                __context__.SourceCodeLine = 38;
                ENDYEAR = (int) ( I ) ; 
                } 
            
            __context__.SourceCodeLine = 42;
            int __FN_FORSTART_VAL__1 = (int) ( STARTYEAR ) ;
            int __FN_FOREND_VAL__1 = (int)ENDYEAR; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (int)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 44;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( I , 400 ) == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 44;
                    LY = (int) ( 1 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 45;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( I , 100 ) == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 45;
                        LY = (int) ( 0 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 46;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Mod( I , 4 ) == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 46;
                            LY = (int) ( 1 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 47;
                            LY = (int) ( 0 ) ; 
                            }
                        
                        }
                    
                    }
                
                __context__.SourceCodeLine = 49;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LY == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 49;
                    LEAPYEARS = (int) ( (LEAPYEARS + 1) ) ; 
                    }
                
                __context__.SourceCodeLine = 42;
                } 
            
            __context__.SourceCodeLine = 52;
            return (uint)( LEAPYEARS) ; 
            
            }
            
        private ushort DAYS_IN_MONTH (  SplusExecutionContext __context__, uint MONTHNUM ) 
            { 
            ushort MLENGTH = 0;
            
            
            __context__.SourceCodeLine = 62;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)MONTHNUM);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 64;
                        MLENGTH = (ushort) ( 31 ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 66;
                        MLENGTH = (ushort) ( 28 ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 67;
                        MLENGTH = (ushort) ( 31 ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                        {
                        __context__.SourceCodeLine = 68;
                        MLENGTH = (ushort) ( 30 ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                        {
                        __context__.SourceCodeLine = 69;
                        MLENGTH = (ushort) ( 31 ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                        {
                        __context__.SourceCodeLine = 70;
                        MLENGTH = (ushort) ( 30 ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                        {
                        __context__.SourceCodeLine = 71;
                        MLENGTH = (ushort) ( 31 ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                        {
                        __context__.SourceCodeLine = 72;
                        MLENGTH = (ushort) ( 31 ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 9) ) ) ) 
                        {
                        __context__.SourceCodeLine = 73;
                        MLENGTH = (ushort) ( 30 ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 10) ) ) ) 
                        {
                        __context__.SourceCodeLine = 74;
                        MLENGTH = (ushort) ( 31 ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 11) ) ) ) 
                        {
                        __context__.SourceCodeLine = 75;
                        MLENGTH = (ushort) ( 30 ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 12) ) ) ) 
                        {
                        __context__.SourceCodeLine = 76;
                        MLENGTH = (ushort) ( 31 ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 80;
            return (ushort)( MLENGTH) ; 
            
            }
            
        private uint DAYS_FROM_ZERO (  SplusExecutionContext __context__, uint I_DAY , uint I_MON , int I_YR , ushort BCE ) 
            { 
            ushort I = 0;
            
            uint MONTHDAYS = 0;
            
            int DIST = 0;
            
            
            __context__.SourceCodeLine = 94;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I_MON > 2 ))  ) ) 
                {
                __context__.SourceCodeLine = 94;
                DIST = (int) ( ((I_YR * 365) + CHECK_FOR_LEAPYEARS( __context__ , (int)( 0 ) , (int)( I_YR ) )) ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 95;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I_MON <= 2 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 95;
                    DIST = (int) ( ((I_YR * 365) + CHECK_FOR_LEAPYEARS( __context__ , (int)( 0 ) , (int)( (I_YR - 1) ) )) ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 98;
            if ( Functions.TestForTrue  ( ( BCE)  ) ) 
                { 
                __context__.SourceCodeLine = 100;
                DIST = (int) ( (DIST * Functions.ToSignedLongInteger( -( 1 ) )) ) ; 
                __context__.SourceCodeLine = 101;
                if ( Functions.TestForTrue  ( ( 0)  ) ) 
                    {
                    __context__.SourceCodeLine = 101;
                    Print( "We have a BCE value!") ; 
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 103;
                DIST = (int) ( (DIST - 367) ) ; 
                }
            
            __context__.SourceCodeLine = 105;
            if ( Functions.TestForTrue  ( ( 0)  ) ) 
                {
                __context__.SourceCodeLine = 105;
                Print( "Days from 1/1/1 to date, including leap years: {0:d}", (int)DIST) ; 
                }
            
            __context__.SourceCodeLine = 110;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( I_MON > 1 ))  ) ) 
                { 
                __context__.SourceCodeLine = 112;
                MONTHDAYS = (uint) ( 0 ) ; 
                __context__.SourceCodeLine = 114;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)(I_MON - 1); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    {
                    __context__.SourceCodeLine = 114;
                    MONTHDAYS = (uint) ( (MONTHDAYS + DAYS_IN_MONTH( __context__ , (uint)( I ) )) ) ; 
                    __context__.SourceCodeLine = 114;
                    }
                
                __context__.SourceCodeLine = 115;
                DIST = (int) ( (DIST + MONTHDAYS) ) ; 
                __context__.SourceCodeLine = 117;
                if ( Functions.TestForTrue  ( ( 0)  ) ) 
                    {
                    __context__.SourceCodeLine = 117;
                    Print( "Days in all of the months from the start of the year to date: {0:d}", (int)MONTHDAYS) ; 
                    }
                
                } 
            
            __context__.SourceCodeLine = 121;
            DIST = (int) ( (DIST + I_DAY) ) ; 
            __context__.SourceCodeLine = 123;
            return (uint)( DIST) ; 
            
            }
            
        private ushort CHECK_SYNTAX (  SplusExecutionContext __context__, uint I_DAY , uint I_MON , uint I_YR ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 134;
            I = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 137;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (I_YR == 0))  ) ) 
                {
                __context__.SourceCodeLine = 137;
                I = (ushort) ( 1 ) ; 
                }
            
            __context__.SourceCodeLine = 140;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( I_MON > 12 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( I_MON < 1 ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 140;
                I = (ushort) ( 2 ) ; 
                }
            
            __context__.SourceCodeLine = 143;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( I_DAY < 1 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( I_DAY > DAYS_IN_MONTH( __context__ , (uint)( I_MON ) ) ) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 143;
                I = (ushort) ( 3 ) ; 
                }
            
            __context__.SourceCodeLine = 145;
            return (ushort)( I) ; 
            
            }
            
        object CALCOLA_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                int [] START;
                int [] END;
                int I = 0;
                int DAYSFROMMONTHS = 0;
                int STARTDIST = 0;
                int ENDDIST = 0;
                int [] DIFF;
                int DIFFMINUTI = 0;
                START  = new int[ 7 ];
                END  = new int[ 7 ];
                DIFF  = new int[ 5 ];
                
                ushort TEMPERR = 0;
                ushort LOC1 = 0;
                ushort LOC2 = 0;
                ushort GL_ERR = 0;
                ushort OGGI = 0;
                ushort DOMANI = 0;
                ushort DOPODOMANI = 0;
                
                CrestronString DATEDIFF;
                DATEDIFF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
                
                CrestronString STARTDATE;
                STARTDATE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
                
                CrestronString STARTTIME;
                STARTTIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
                
                CrestronString ENDDATE;
                ENDDATE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
                
                CrestronString ENDTIME;
                ENDTIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 128, this );
                
                
                __context__.SourceCodeLine = 159;
                STARTDATE  .UpdateValue ( "1/17/1980"  ) ; 
                __context__.SourceCodeLine = 160;
                STARTTIME  .UpdateValue ( "21:18:00"  ) ; 
                __context__.SourceCodeLine = 161;
                ENDDATE  .UpdateValue ( Functions.Date (  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 162;
                ENDTIME  .UpdateValue ( "00:00:00"  ) ; 
                __context__.SourceCodeLine = 184;
                GL_ERR = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 187;
                LOC1 = (ushort) ( Functions.Find( "/" , STARTDATE ) ) ; 
                __context__.SourceCodeLine = 188;
                LOC2 = (ushort) ( Functions.Find( "/" , STARTDATE , (LOC1 + 1) ) ) ; 
                __context__.SourceCodeLine = 189;
                START [ 0] = (int) ( Functions.Atol( Functions.Mid( STARTDATE , (int)( (LOC1 + 1) ) , (int)( (LOC2 - LOC1) ) ) ) ) ; 
                __context__.SourceCodeLine = 190;
                START [ 1] = (int) ( Functions.Atol( Functions.Left( STARTDATE , (int)( ((Functions.Length( STARTDATE ) - LOC1) + 1) ) ) ) ) ; 
                __context__.SourceCodeLine = 191;
                START [ 2] = (int) ( Functions.Atol( Functions.Right( STARTDATE , (int)( (Functions.Length( STARTDATE ) - LOC2) ) ) ) ) ; 
                __context__.SourceCodeLine = 193;
                if ( Functions.TestForTrue  ( ( 0)  ) ) 
                    {
                    __context__.SourceCodeLine = 193;
                    Print( "Current start date values {0:d}/{1:d}/{2:d} and loc values {3:d} - {4:d}", (int)START[ 1 ], (int)START[ 0 ], (int)START[ 2 ], (short)LOC1, (short)LOC2) ; 
                    }
                
                __context__.SourceCodeLine = 195;
                LOC1 = (ushort) ( Functions.Find( "/" , ENDDATE ) ) ; 
                __context__.SourceCodeLine = 196;
                LOC2 = (ushort) ( Functions.Find( "/" , ENDDATE , (LOC1 + 1) ) ) ; 
                __context__.SourceCodeLine = 197;
                END [ 0] = (int) ( Functions.Atol( Functions.Mid( ENDDATE , (int)( (LOC1 + 1) ) , (int)( (LOC2 - LOC1) ) ) ) ) ; 
                __context__.SourceCodeLine = 198;
                END [ 1] = (int) ( Functions.Atol( Functions.Left( ENDDATE , (int)( ((Functions.Length( ENDDATE ) - LOC1) + 1) ) ) ) ) ; 
                __context__.SourceCodeLine = 199;
                END [ 2] = (int) ( Functions.Atol( Functions.Right( ENDDATE , (int)( (Functions.Length( ENDDATE ) - LOC2) ) ) ) ) ; 
                __context__.SourceCodeLine = 201;
                if ( Functions.TestForTrue  ( ( 0)  ) ) 
                    {
                    __context__.SourceCodeLine = 201;
                    Print( "Current end date values {0:d}/{1:d}/{2:d}", (int)END[ 1 ], (int)END[ 0 ], (int)END[ 2 ]) ; 
                    }
                
                __context__.SourceCodeLine = 203;
                LOC1 = (ushort) ( Functions.Find( ":" , STARTTIME ) ) ; 
                __context__.SourceCodeLine = 204;
                LOC2 = (ushort) ( Functions.Find( ":" , STARTTIME , (LOC1 + 1) ) ) ; 
                __context__.SourceCodeLine = 205;
                START [ 3] = (int) ( Functions.Atol( Functions.Left( STARTTIME , (int)( ((Functions.Length( STARTTIME ) - LOC1) + 1) ) ) ) ) ; 
                __context__.SourceCodeLine = 206;
                START [ 4] = (int) ( Functions.Atol( Functions.Mid( STARTTIME , (int)( (LOC1 + 1) ) , (int)( (LOC2 - LOC1) ) ) ) ) ; 
                __context__.SourceCodeLine = 207;
                START [ 5] = (int) ( Functions.Atol( Functions.Right( STARTTIME , (int)( (Functions.Length( STARTTIME ) - LOC2) ) ) ) ) ; 
                __context__.SourceCodeLine = 209;
                if ( Functions.TestForTrue  ( ( 0)  ) ) 
                    {
                    __context__.SourceCodeLine = 209;
                    Print( "Current start time values {0:d}:{1:d}:{2:d} and loc values {3:d} - {4:d}", (int)START[ 3 ], (int)START[ 4 ], (int)START[ 5 ], (short)LOC1, (short)LOC2) ; 
                    }
                
                __context__.SourceCodeLine = 211;
                LOC1 = (ushort) ( Functions.Find( ":" , ENDTIME ) ) ; 
                __context__.SourceCodeLine = 212;
                LOC2 = (ushort) ( Functions.Find( ":" , ENDTIME , (LOC1 + 1) ) ) ; 
                __context__.SourceCodeLine = 213;
                END [ 3] = (int) ( Functions.Atol( Functions.Left( ENDTIME , (int)( ((Functions.Length( ENDTIME ) - LOC1) + 1) ) ) ) ) ; 
                __context__.SourceCodeLine = 214;
                END [ 4] = (int) ( Functions.Atol( Functions.Mid( ENDTIME , (int)( (LOC1 + 1) ) , (int)( (LOC2 - LOC1) ) ) ) ) ; 
                __context__.SourceCodeLine = 215;
                END [ 5] = (int) ( Functions.Atol( Functions.Right( ENDTIME , (int)( (Functions.Length( ENDTIME ) - LOC2) ) ) ) ) ; 
                __context__.SourceCodeLine = 217;
                if ( Functions.TestForTrue  ( ( 0)  ) ) 
                    {
                    __context__.SourceCodeLine = 217;
                    Print( "Current end time values {0:d}:{1:d}:{2:d}", (int)END[ 3 ], (int)END[ 4 ], (int)END[ 5 ]) ; 
                    }
                
                __context__.SourceCodeLine = 220;
                TEMPERR = (ushort) ( CHECK_SYNTAX( __context__ , (uint)( START[ 0 ] ) , (uint)( START[ 1 ] ) , (uint)( START[ 2 ] ) ) ) ; 
                __context__.SourceCodeLine = 221;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TEMPERR != 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 221;
                    GL_ERR = (ushort) ( TEMPERR ) ; 
                    }
                
                __context__.SourceCodeLine = 222;
                TEMPERR = (ushort) ( (CHECK_SYNTAX( __context__ , (uint)( END[ 0 ] ) , (uint)( END[ 1 ] ) , (uint)( END[ 2 ] ) ) * 10) ) ; 
                __context__.SourceCodeLine = 223;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TEMPERR != 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 223;
                    GL_ERR = (ushort) ( TEMPERR ) ; 
                    }
                
                __context__.SourceCodeLine = 226;
                STARTDIST = (int) ( DAYS_FROM_ZERO( __context__ , (uint)( START[ 0 ] ) , (uint)( START[ 1 ] ) , (int)( START[ 2 ] ) , (ushort)( 0 ) ) ) ; 
                __context__.SourceCodeLine = 227;
                ENDDIST = (int) ( DAYS_FROM_ZERO( __context__ , (uint)( END[ 0 ] ) , (uint)( END[ 1 ] ) , (int)( END[ 2 ] ) , (ushort)( 0 ) ) ) ; 
                __context__.SourceCodeLine = 229;
                if ( Functions.TestForTrue  ( ( 0)  ) ) 
                    {
                    __context__.SourceCodeLine = 229;
                    Print( "All days from 1/1/1 to start date: {0:d}", (int)STARTDIST) ; 
                    }
                
                __context__.SourceCodeLine = 230;
                if ( Functions.TestForTrue  ( ( 0)  ) ) 
                    {
                    __context__.SourceCodeLine = 230;
                    Print( "All days from 1/1/1 to end date: {0:d}", (int)ENDDIST) ; 
                    }
                
                __context__.SourceCodeLine = 245;
                DIFF [ 0] = (int) ( (ENDDIST - STARTDIST) ) ; 
                __context__.SourceCodeLine = 247;
                DIFF [ 1] = (int) ( (END[ 3 ] - START[ 3 ]) ) ; 
                __context__.SourceCodeLine = 249;
                DIFF [ 2] = (int) ( (END[ 4 ] - START[ 4 ]) ) ; 
                __context__.SourceCodeLine = 251;
                DIFF [ 3] = (int) ( (END[ 5 ] - START[ 5 ]) ) ; 
                __context__.SourceCodeLine = 254;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( DIFF[ 3 ] < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 256;
                    DIFF [ 3] = (int) ( (DIFF[ 3 ] + 60) ) ; 
                    __context__.SourceCodeLine = 257;
                    DIFF [ 2] = (int) ( (DIFF[ 2 ] - 1) ) ; 
                    } 
                
                __context__.SourceCodeLine = 260;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( DIFF[ 2 ] < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 262;
                    DIFF [ 2] = (int) ( (DIFF[ 2 ] + 60) ) ; 
                    __context__.SourceCodeLine = 263;
                    DIFF [ 1] = (int) ( (DIFF[ 1 ] - 1) ) ; 
                    } 
                
                __context__.SourceCodeLine = 266;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( DIFF[ 1 ] < 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 268;
                    DIFF [ 1] = (int) ( (DIFF[ 1 ] + 24) ) ; 
                    __context__.SourceCodeLine = 269;
                    DIFF [ 0] = (int) ( (DIFF[ 0 ] - 1) ) ; 
                    } 
                
                __context__.SourceCodeLine = 273;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (GL_ERR != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 275;
                    if ( Functions.TestForTrue  ( ( 0)  ) ) 
                        {
                        __context__.SourceCodeLine = 275;
                        Print( "******* ERROR *******") ; 
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 277;
                    if ( Functions.TestForTrue  ( ( 0)  ) ) 
                        {
                        __context__.SourceCodeLine = 277;
                        Print( "Difference is {0:d}", (int)DIFF[ 0 ]) ; 
                        }
                    
                    }
                
                __context__.SourceCodeLine = 279;
                if ( Functions.TestForTrue  ( ( 0)  ) ) 
                    {
                    __context__.SourceCodeLine = 279;
                    Print( "gl_error is {0:d}", (short)GL_ERR) ; 
                    }
                
                __context__.SourceCodeLine = 282;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_2__ = ((int)GL_ERR);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 0) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 286;
                            DATEDIFF  .UpdateValue ( Functions.LtoA (  (int) ( DIFF[ 0 ] ) ) + "." + Functions.LtoA (  (int) ( DIFF[ 1 ] ) ) + "." + Functions.LtoA (  (int) ( DIFF[ 2 ] ) ) + "." + Functions.LtoA (  (int) ( DIFF[ 3 ] ) )  ) ; 
                            __context__.SourceCodeLine = 287;
                            DIFFMINUTI = (int) ( ((DIFF[ 0 ] * 24) * 60) ) ; 
                            __context__.SourceCodeLine = 288;
                            DIFFMINUTI = (int) ( ((DIFFMINUTI + (DIFF[ 1 ] * 60)) + DIFF[ 2 ]) ) ; 
                            __context__.SourceCodeLine = 289;
                            DIFFMINUTI = (int) ( (Mod( DIFFMINUTI , 42524 ) / (42524 / 24)) ) ; 
                            __context__.SourceCodeLine = 290;
                            DIFFMINUTI = (int) ( Mod( (DIFFMINUTI + 1) , 24 ) ) ; 
                            __context__.SourceCodeLine = 291;
                            OGGI = (ushort) ( DIFFMINUTI ) ; 
                            __context__.SourceCodeLine = 292;
                            DOMANI = (ushort) ( (DIFFMINUTI + 1) ) ; 
                            __context__.SourceCodeLine = 293;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DOMANI == 24))  ) ) 
                                {
                                __context__.SourceCodeLine = 293;
                                DOMANI = (ushort) ( 0 ) ; 
                                }
                            
                            __context__.SourceCodeLine = 294;
                            DOPODOMANI = (ushort) ( (DOMANI + 1) ) ; 
                            __context__.SourceCodeLine = 295;
                            FASELUNAREOGGI  .Value = (ushort) ( Functions.Atosi( Functions.LtoA( (int)( OGGI ) ) ) ) ; 
                            __context__.SourceCodeLine = 296;
                            FASELUNAREDOMANI  .Value = (ushort) ( Functions.Atosi( Functions.LtoA( (int)( DOMANI ) ) ) ) ; 
                            __context__.SourceCodeLine = 297;
                            FASELUNAREDOPODOMANI  .Value = (ushort) ( Functions.Atosi( Functions.LtoA( (int)( DOPODOMANI ) ) ) ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == (  (int) ( 1 ) ) ) ) ) 
                            {
                            __context__.SourceCodeLine = 299;
                            DATEDIFF  .UpdateValue ( "Error: Bad starting year value (probably because there's no year 0)"  ) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                            {
                            __context__.SourceCodeLine = 300;
                            DATEDIFF  .UpdateValue ( "Error: Bad starting month value (out of range)"  ) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 3) ) ) ) 
                            {
                            __context__.SourceCodeLine = 301;
                            DATEDIFF  .UpdateValue ( "Error: Bad starting day value (out of range)"  ) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                            {
                            __context__.SourceCodeLine = 302;
                            DATEDIFF  .UpdateValue ( "Error: That's not a real month!"  ) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 10) ) ) ) 
                            {
                            __context__.SourceCodeLine = 303;
                            DATEDIFF  .UpdateValue ( "Error: Bad ending year value (probably because there's no year 0)"  ) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 20) ) ) ) 
                            {
                            __context__.SourceCodeLine = 304;
                            DATEDIFF  .UpdateValue ( "Error: Bad ending month value (out of range)"  ) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 30) ) ) ) 
                            {
                            __context__.SourceCodeLine = 305;
                            DATEDIFF  .UpdateValue ( "Error: Bad ending day value (out of range)"  ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 306;
                            DATEDIFF  .UpdateValue ( "Error: Unknown (how did you get this message?)"  ) ; 
                            }
                        
                        } 
                        
                    }
                    
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        SocketInfo __socketinfo__ = new SocketInfo( 1, this );
        InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
        _SplusNVRAM = new SplusNVRAM( this );
        
        CALCOLA = new Crestron.Logos.SplusObjects.DigitalInput( CALCOLA__DigitalInput__, this );
        m_DigitalInputList.Add( CALCOLA__DigitalInput__, CALCOLA );
        
        FASELUNAREOGGI = new Crestron.Logos.SplusObjects.AnalogOutput( FASELUNAREOGGI__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( FASELUNAREOGGI__AnalogSerialOutput__, FASELUNAREOGGI );
        
        FASELUNAREDOMANI = new Crestron.Logos.SplusObjects.AnalogOutput( FASELUNAREDOMANI__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( FASELUNAREDOMANI__AnalogSerialOutput__, FASELUNAREDOMANI );
        
        FASELUNAREDOPODOMANI = new Crestron.Logos.SplusObjects.AnalogOutput( FASELUNAREDOPODOMANI__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( FASELUNAREDOPODOMANI__AnalogSerialOutput__, FASELUNAREDOPODOMANI );
        
        
        CALCOLA.OnDigitalPush.Add( new InputChangeHandlerWrapper( CALCOLA_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_DATE_DIFF ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint CALCOLA__DigitalInput__ = 0;
    const uint FASELUNAREOGGI__AnalogSerialOutput__ = 0;
    const uint FASELUNAREDOMANI__AnalogSerialOutput__ = 1;
    const uint FASELUNAREDOPODOMANI__AnalogSerialOutput__ = 2;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        
    }
    
    SplusNVRAM _SplusNVRAM = null;
    
    public class __CEvent__ : CEvent
    {
        public __CEvent__() {}
        public void Close() { base.Close(); }
        public int Reset() { return base.Reset() ? 1 : 0; }
        public int Set() { return base.Set() ? 1 : 0; }
        public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
    }
    public class __CMutex__ : CMutex
    {
        public __CMutex__() {}
        public void Close() { base.Close(); }
        public void ReleaseMutex() { base.ReleaseMutex(); }
        public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
    }
     public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
